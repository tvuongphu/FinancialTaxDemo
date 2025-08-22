namespace GlobalTaxCalculation.Application.Models;

public record TransJobDto(long? JobNumber, bool? Success, string Request, string Response);
