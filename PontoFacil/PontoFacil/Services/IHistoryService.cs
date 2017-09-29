﻿using System.Collections.Generic;
using PontoFacil.Models;
using System;

namespace PontoFacil.Services
{
    public interface IHistoryService
    {
        List<ClockIn> GetMonthlyHistory();
        List<ClockIn> GetFreeHistory(DateTimeOffset startDate, DateTimeOffset endDate);

        ClockIn UpdateClockIn(ClockIn clockIn);
        ClockIn AllowWaiver(ClockIn clockIn);
    }
}