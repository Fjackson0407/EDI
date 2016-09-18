using Valid.Fulfillment.PostSharp;

//These entries setup the configuration for postsharp to include this project for logging purposes
[assembly: LogException(AttributeTargetTypes = "Valid.Fulfillment.Common.*", AspectPriority = 1)]
[assembly: LogTrace(AttributeTargetTypes = "Valid.Fulfillment.Common.*", AttributeExclude = true, AttributeTargetMembers = "regex:get_.*|set_.*")]
[assembly: LogTrace(AttributeTargetTypes = "Valid.Fulfillment.Common.*", AspectPriority = 2)]
