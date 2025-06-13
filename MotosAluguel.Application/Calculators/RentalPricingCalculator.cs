using MotosAluguel.Domain.Entities.Rentals;

namespace MotosAluguel.Application.Calculators;

public static class RentalPricingCalculator
{
    private static readonly Dictionary<int, long> DailyRates = new()
    {
        { 7, 30000 },
        { 15, 28000 },
        { 30, 22000 },
        { 45, 20000 },
        { 50, 18000 }
    };

    public static long CalculateRentalCost(Rental rental)
    {
        long amountToPay = 0;
        int totalDays = (rental.EstimatedEndDate - rental.BeginAt).Days;
        int actualDays = (rental.EndAt - rental.BeginAt).Days;
        long dailyRate = DailyRates[rental.Plan];

        ApplyBaseAmountDailyRental(ref amountToPay,actualDays, dailyRate);
        ApplyEarlyReturnPenalty(ref amountToPay,rental, totalDays, actualDays, dailyRate);
        ApplyLateReturnPenalty(ref amountToPay,rental);

        return amountToPay;
    }

    private static void ApplyBaseAmountDailyRental(
        ref long amountToPay,
        int actualDays,
        long dailyRate)
    {
        amountToPay += actualDays * dailyRate;
    }

    private static void ApplyEarlyReturnPenalty(
        ref long amountToPay,
        Rental rental,
        int totalDays,
        int actualDays,
        long dailyRate)
    {
        if (rental.EndAt < rental.EstimatedEndDate && rental.Plan <= 15)
        {
            int daysNotUsed = totalDays - actualDays;
            double penaltyRate = rental.Plan == 7 ? 0.20 : 0.40;
            amountToPay += (long)(daysNotUsed * dailyRate * penaltyRate);
        }
    }

    private static void ApplyLateReturnPenalty(
        ref long amountToPay,
        Rental rental)
    {
        if (rental.EndAt > rental.EstimatedEndDate)
        {
            int extraDays = (rental.EndAt - rental.EstimatedEndDate).Days;
            amountToPay += extraDays * 50000;
        }
    }
}
