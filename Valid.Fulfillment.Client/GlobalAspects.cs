using Valid.Fulfillment.PostSharp;

//These entries setup the configuration for postsharp to include this project for logging purposes
[assembly: LogException(AttributeTargetTypes = "Valid.Fulfillment.Client.*", AspectPriority = 1)]
[assembly: LogTrace(AttributeTargetTypes = "Valid.Fulfillment.Client.*", AttributeExclude = true, AttributeTargetMembers = "regex:get_.*|set_.*")]
[assembly: LogTrace(AttributeTargetTypes = "Valid.Fulfillment.Client.*", AspectPriority = 2)]
