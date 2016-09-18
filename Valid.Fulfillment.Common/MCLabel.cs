using Domain;
using Helpers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static Helpers.EDIHelperFunctions;

namespace Valid.Fulfillment.Common.MCLabel
{
    public class MCLabel
    {
        public string FilePath { get; set; }
        public string ConnectionString { get; set; }
        public string NewLabelFile { get; set; }

        public MCLabel(string _FilePath, string _ConnectionString, string _NewLabelFile)
        {
            if (!Directory.Exists(Path.GetFullPath(_FilePath)))
            {
                Directory.CreateDirectory(Path.GetFullPath(_FilePath));
            }
            FilePath = _FilePath;
            ConnectionString = _ConnectionString;
            NewLabelFile = Path.Combine(_FilePath, _NewLabelFile);
        }

        public void SavetoFile(string cSVFiile)
        {
            using (StreamWriter sw = new StreamWriter(NewLabelFile))
            {
                sw.WriteLine(cSVFiile);
            }
        }

        public  string ConvertToString(List<Label> lisSSCC)
        {
            StringBuilder cStringBuilder = new StringBuilder();
            cStringBuilder.Append(From);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(Faddress);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(Fcity);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(Fstate);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(Fzip);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(To);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(Taddress);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(Tcity);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(Tstate);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(Tzip);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(po);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(DCLocation);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(EDIHelperFunctions.SSCC);
            cStringBuilder.Append(Comma);
            cStringBuilder.Append(StoreID);
            cStringBuilder.Append(LineBreak);

            foreach (Label label in lisSSCC)
            {
                cStringBuilder.Append(label.From);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.Faddress);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.Fcity);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.Fstate);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.FZip);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.To);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.Taddress);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.Tcity);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.Tstate);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.Tzip);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.PONumber);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.DcNumber);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.SSCC);
                cStringBuilder.Append(Comma);
                cStringBuilder.Append(label.OrderStoreNumber);
                cStringBuilder.Append(LineBreak);
            }
            SavetoFile(cStringBuilder.ToString());
            return cStringBuilder.ToString();
        }

    }
}
