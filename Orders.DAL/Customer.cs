﻿namespace Orders.DAL;

public partial class Customer
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public decimal? AnnualIncome { get; set; }

}
