﻿namespace Shared.DataTransferObjects;

public record WalletDto
{
	public Guid Id { get; init; }

    public Guid userId { get; init; }
    public string currency { get; init; }
    public decimal amount { get; init; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
