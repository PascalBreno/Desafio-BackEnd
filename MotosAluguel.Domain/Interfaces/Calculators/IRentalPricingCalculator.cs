using MotosAluguel.Domain.Entities.Rentals;

namespace MotosAluguel.Domain.Interfaces.Calculators;

public interface IRentalPricingCalculator
{
    long CalculateRentalCost(Rental rental, DateTime returnDate);
}
