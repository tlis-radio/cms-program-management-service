using System;

namespace Tlis.Cms.ProgramManagement.Infrastructure.Exceptions;

public class EntityNotFoundException(string? message = null) : Exception(message);