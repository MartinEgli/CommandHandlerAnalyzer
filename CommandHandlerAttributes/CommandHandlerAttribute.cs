using System;

namespace CommandHandlerAttributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class CommandHandlerAttribute : Attribute{}