using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Valid.Fulfillment.Common
{
    /// <summary>
    /// This class will allow you to add scanning ability to a form without forcing the user 
    /// to put the cursor in a specific location.
    /// This class can be instantiated inside a WPF Window to catch Scanner Keyboard Emulation.
    /// You need to pass the Window and Key Prefix and Suffix (either the character itself or the ASCII Code) 
    /// for the character that it should look for in the constructor.  
    /// </summary>
    public class ScannerCapture : ApplicationException
    {

        #region Class Variables

        private Window m_window = null;
        private bool m_enabled = true;
        private string m_scanValue = string.Empty;
        private int? m_scanPrefixASCIICode = null;
        private int? m_scanSuffixASCIICode = null;
        private DateTime? m_scanningBeganDateTime = null;
        private short[] m_validScanLengths = null;
        private short m_maximumMillisecondsPerCharacter = 50;
        private DateTime? m_previousCharacterScanned = null;

        #endregion Class Variables

        #region Events

        public delegate void ScanBeginHandler();
        /// <summary>
        /// This event is raised after the Scan Prefix has been processed.
        /// </summary>
        public event ScanBeginHandler ScanBegin;

        public delegate void ScanCompleteHandler(string scanValue);
        /// <summary>
        /// This event is raised after the Scan is successfully completed.
        /// </summary>
        public event ScanCompleteHandler ScanComplete;

        public delegate void ScanErrorHandler(string errorMessage);
        /// <summary>
        /// This event is raised if the Scan does not meet the specified criteria.
        /// </summary>
        public event ScanErrorHandler ScanError;

        #endregion Events

        #region Constructors

        /// <summary>
        /// Creates a new Instance of the Scanner Capture Class.  
        /// It is recommmended that you use the constructor that accepts the EScannerCaptureUnprintableCharacters enums 
        /// and program those in the prefix and suffix on the scanner.
        /// It is also recommended you handle both the ScanComplete and ScanError events.
        /// </summary>
        /// <param name="window">The Window you want to allow the scanning to happen on.</param>
        /// <param name="maximumMillisecondsPerCharacter">
        /// The Milliseconds the scan must be completed in to be a valid scan.
        /// It is recommended you start at 50 and also make it configurable in your application.
        /// This will help the class determine if someone is typing the characters or the value was scanned.
        /// </param>
        /// <param name="scanPrefix">The character that is programmed as the prefix on the scanner.</param>
        /// <param name="scanSuffix">The character that is programmed as the suffix on the scanner.</param>
        /// <param name="validScanLengths">The lengths of the scans you are expecting.  
        /// An error will be thrown if the scan length is not equal to one of the expected lengths.
        /// </param>
        public ScannerCapture(Window window, short maximumMillisecondsPerCharacter, char scanPrefix, char scanSuffix, params short[] validScanLengths)
            : this(window, maximumMillisecondsPerCharacter, (int)scanPrefix, (int)scanSuffix, validScanLengths)
        {
        }

        /// <summary>
        /// Creates a new Instance of the ScannerKeyboard Emulation Class.  
        /// This is the recommended constructor if the scanner can be programmed for unprintable characters. 
        /// It is also recommended you handle both the ScanComplete and ScanError events.
        /// </summary>
        /// <param name="window">The Window you want to allow the scanning to happen on.</param>
        /// <param name="maximumMillisecondsPerCharacter">
        /// The Milliseconds the scan must be completed in to be a valid scan.
        /// It is recommended you start at 50 and also make it configurable in your application.
        /// This will help the class determine if someone is typing the characters or the value was scanned.
        /// </param>
        /// <param name="scanPrefix">The unprintable character that is programmed as the prefix on the scanner.</param>
        /// <param name="scanSuffix">The unprintable character that is programmed as the suffix on the scanner.</param>
        /// <param name="validScanLengths">The lengths of the scans you are expecting.  
        /// An error will be thrown if the scan length is not equal to one of the expected lengths.
        /// </param>
        public ScannerCapture(Window window, short maximumMillisecondsPerCharacter, EScannerCaptureUnprintableCharacters scanPrefix, EScannerCaptureUnprintableCharacters scanSuffix, params short[] validScanLengths)
        : this(window, maximumMillisecondsPerCharacter, (int)scanPrefix, (int)scanSuffix, validScanLengths)
        {
        }

        /// <summary>
        /// Creates a new Instance of the ScannerKeyboard Emulation Class.  
        /// This is the recommended constructor if the scanner can be programmed for unprintable characters. 
        /// It is also recommended you handle both the ScanComplete and ScanError events.
        /// </summary>
        /// <param name="window">The Window you want to allow the scanning to happen on.</param>
        /// <param name="maximumMillisecondsPerCharacter">
        /// The Milliseconds the scan must be completed in to be a valid scan.
        /// It is recommended you start at 50 and also make it configurable in your application.
        /// This will help the class determine if someone is typing the characters or the value was scanned.
        /// </param>
        /// <param name="scanPrefix">The ASCII code for the prefix that is programmed on the scanner.</param>
        /// <param name="scanSuffix">The ASCII code for the suffix that is programmed on the scanner.</param>
        /// <param name="validScanLengths">The lengths of the scans you are expecting.  
        /// An error will be thrown if the scan length is not equal to one of the expected lengths.
        /// </param>
        private ScannerCapture(Window window, short maximumMillisecondsPerCharacter, int scanPrefixASCIICode, int scanSuffixASCIICode, params short[] validScanLengths)
        {
            m_window = window;
            m_scanPrefixASCIICode = scanPrefixASCIICode;
            m_scanSuffixASCIICode = scanSuffixASCIICode;
            m_maximumMillisecondsPerCharacter = maximumMillisecondsPerCharacter;
            m_validScanLengths = validScanLengths;
            m_window.PreviewTextInput += PreviewTextInput;
        }

        /// <summary>
        /// Creates a new Instance of the Scanner Capture Class.  
        /// This is the recommended constructor if the scanner can be programmed for unprintable characters. 
        /// It is also recommended you handle both the ScanComplete and ScanError events.
        /// </summary>
        /// <param name="userControl">The User Control you want to allow the scanning to happen on.</param>
        /// <param name="maximumMillisecondsPerCharacter">
        /// The Milliseconds the scan must be completed in to be a valid scan.
        /// It is recommended you start at 50 and also make it configurable in your application.
        /// This will help the class determine if someone is typing the characters or the value was scanned.
        /// </param>
        /// <param name="scanPrefix">The unprintable character that is programmed as the prefix on the scanner.</param>
        /// <param name="scanSuffix">The unprintable character that is programmed as the suffix on the scanner.</param>
        /// <param name="validScanLengths">The lengths of the scans you are expecting.  
        /// An error will be thrown if the scan length is not equal to one of the expected lengths.
        /// </param>
        public ScannerCapture(System.Windows.Controls.UserControl userControl, short maximumMillisecondsPerCharacter, EScannerCaptureUnprintableCharacters scanPrefix, EScannerCaptureUnprintableCharacters scanSuffix, params short[] validScanLengths)
        {
            m_scanPrefixASCIICode = (int)scanPrefix;
            m_scanSuffixASCIICode = (int)scanSuffix;
            m_maximumMillisecondsPerCharacter = maximumMillisecondsPerCharacter;
            m_validScanLengths = validScanLengths;

            DependencyObject dpParent = userControl.Parent;
            while (dpParent != null)
            {
                if (dpParent is Window)
                {
                    m_window = (Window)dpParent;
                    break;
                }
                else
                {
                    dpParent = LogicalTreeHelper.GetParent(dpParent);
                }
            }

            if (m_window == null)
                throw new ApplicationException(string.Format("UserControl:{0} does not have a Window as a Parent", userControl.Name));
            else
                m_window.PreviewTextInput += new TextCompositionEventHandler(PreviewTextInput);
        }

        #endregion Constructors

        #region Properties

        public bool Enabled
        {
            get { return m_enabled; }
            set
            {
                if (m_enabled && !value)
                {
                    Clear();
                    m_scanValue = string.Empty;
                }

                m_enabled = value;
            }
        }

        private bool ScanningHasBegun
        {
            get { return m_scanningBeganDateTime != null; }
        }

        #endregion Properties

        #region Event Handlers

        /// <summary>
        /// This Event is executed anytime a key is pressed on the m_window's keyboard or a scanner
        /// emulates keyboard input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (m_enabled)      
            {
                if (IsScanPrefix(e))
                {
                    if (ScanBegin != null)
                        ScanBegin();
                    e.Handled = true;
                    m_previousCharacterScanned = DateTime.Now;
                }
                else if (IsScanSuffix(e))
                {
                    e.Handled = true;
                    m_previousCharacterScanned = DateTime.Now;
                }
                else if (CharacterWasAddedToScanValue(e))
                {
                    e.Handled = true;
                    m_previousCharacterScanned = DateTime.Now;
                }
                m_scanningBeganDateTime = DateTime.Now;
            }
        }

        #endregion Event Handlers

        #region Private Miscellaneous Methods

        /// <summary>
        /// Clears all the variables for a Scan
        /// </summary>
        private void Clear()
        {
            m_scanValue = string.Empty;
            m_previousCharacterScanned = null;
            m_scanningBeganDateTime = null;
        }

        /// <summary>
        /// Determines if the Text is the Scan Prefix
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool IsScanPrefix(TextCompositionEventArgs e)
        {
            bool result = false;

            if (IsScanCharacterASCIICode(e, m_scanPrefixASCIICode))
            {
                Clear();
                m_scanningBeganDateTime = DateTime.Now;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Adds the Text to the Scan Value if the Scan Prefix was previously entered.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool CharacterWasAddedToScanValue(TextCompositionEventArgs e)
        {
            bool retVal = false;

            if (ScanningHasBegun)
            {
                if (CharacterWasEnteredWithinMaximumMilliseconds())
                {
                    m_scanValue += e.Text;
                    retVal = true;
                }
                else
                {
                    Clear();
                }
            }

            return retVal;
        }

        /// <summary>
        /// Determines if the text is the Scan Suffix.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool IsScanSuffix(TextCompositionEventArgs e)
        {
            bool result = false;

            if (CharacterWasEnteredWithinMaximumMilliseconds())
            {
                if (ScanningHasBegun && IsScanCharacterASCIICode(e, m_scanSuffixASCIICode))
                {
                    string scanValue = m_scanValue;
                    Clear();
                    if (m_validScanLengths == null || m_validScanLengths.Count() == 0
                        || m_validScanLengths.Contains((short) scanValue.Length))
                    {
                        ScanComplete(scanValue);
                    }
                    else
                    {
                        string errorMessage =
                            string.Format(
                                "Scan must be {0} characters - You scanned:{1} which is {2} characters.  Please try again.",
                                m_validScanLengths, scanValue, scanValue.Length);
                        if (ScanError == null)
                        {
                            throw new ScannerCaptureException(errorMessage);
                        }
                        else
                        {
                            ScanError(errorMessage);
                        }
                    }

                    result = true;
                }
            }
            else
                Clear();

            return result;
        }

        private bool IsScanCharacterASCIICode(TextCompositionEventArgs e, int? asciiCode)
        {
            bool retVal = false;
            char? checkChar = null;

            if (!string.IsNullOrEmpty(e.ControlText))
                checkChar = e.ControlText.ToCharArray().First();
            else if (!string.IsNullOrEmpty(e.Text))
                checkChar = e.Text.ToCharArray().First();

            if (checkChar != null)
                retVal = (int)checkChar == asciiCode;

            return retVal;
        }

        private bool CharacterWasEnteredWithinMaximumMilliseconds()
        {
            return (DateDifferenceInMilliseconds(DateTime.Now, m_previousCharacterScanned) <= m_maximumMillisecondsPerCharacter);
        }

        private double DateDifferenceInMilliseconds(DateTime largerDate, DateTime? smallerDate)
        {
            double retVal = 0;

            if (smallerDate != null)
            {
                TimeSpan? ts = largerDate - smallerDate;
                retVal = ((TimeSpan)ts).TotalMilliseconds;
            }

            return retVal;
        }

        #endregion Private Miscellaneous Methods



    }
}


namespace Valid.Fulfillment.Common
{

    /// <summary>
    /// This exception is thrown from the RWS.Common.WPF.ScannerKeyboardEmulation 
    /// class.  If the scanned value is considered invalid.
    /// </summary>
    public class ScannerCaptureException : ApplicationException
    {

        public ScannerCaptureException()
        {
        }

        public ScannerCaptureException(string message)
            : base(message)
        {
        }
    }
}

namespace Valid.Fulfillment.Common
{
    public enum EScannerCaptureUnprintableCharacters
    {
        STX = 2,
        //ETX = 3,  This currently does not work correctly if the Cursor is in a WPF Textbox
        EOT = 4,
        ENQ = 5,
        ACK = 6,
        BEL = 7,
        BS = 8,
        HT = 9,
        LF = 10,
        VT = 11,
        FF = 12,
        CR = 13
    }
}



