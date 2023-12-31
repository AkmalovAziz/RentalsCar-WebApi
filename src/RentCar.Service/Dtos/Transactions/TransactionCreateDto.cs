﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Service.Dtos.Transactions;

public class TransactionCreateDto
{
    public long CarId { get; set; }

    public long ClientId { get; set; }

    public long RentalId { get; set; }

    public string Description { get; set; } = string.Empty;

}
