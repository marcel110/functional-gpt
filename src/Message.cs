﻿namespace FunctionalGPT;

public record Message
{
    public Message(Role role, string content)
    {
        Role = role;
        Content = content;
    }

    public Message(Role role, string name, string content)
    {
        Role = role;
        Name = name;
        Content = content;
    }

    public Message(FunctionCall functionCall)
    {
        Role = Role.Assistant;
        FunctionCall = functionCall;
    }

    public Role Role { get; set; }

    public string? Name { get; set; }

    public string? Content { get; set; }

    public FunctionCall? FunctionCall { get; set; }

    public static Message FromSystem(string content)
    {
        return new Message(Role.System, content);
    }

    public static Message FromUser(string content)
    {
        return new Message(Role.User, content);
    }

    public static Message FromUser(string name, string content)
    {
        return new Message(Role.User, name, content);
    }

    public static Message FromAssistant(string content)
    {
        return new Message(Role.Assistant, content);
    }

    public static Message FromAssistant(FunctionCall functionCall)
    {
        return new Message(functionCall);
    }

    public static Message FromFunction(string name, string content)
    {
        return new Message(Role.Function, name, content);
    }
}
