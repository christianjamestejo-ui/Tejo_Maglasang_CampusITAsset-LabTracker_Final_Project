using System;
namespace MT_Campus_IT_Asset___Lab_Tracker.Functions
{
    public static class DepreciationCalculator
    {
        public static double CalculateStraightLine(
            double purchasePrice,
            double salvagePrice,
            DateTime purchaseDate,
            int usefulLifeMonths)
        {
            if (usefulLifeMonths <= 0)
                throw new ArgumentException("Useful life must be positive.");

            if (purchasePrice < salvagePrice)
                throw new ArgumentException("Purchase price cannot be less than salvage value.");

            int elapsedMonths = Math.Max(
                0,
                ((DateTime.Today.Year - purchaseDate.Year) * 12)
                + DateTime.Today.Month - purchaseDate.Month
            );

            elapsedMonths = Math.Min(elapsedMonths, usefulLifeMonths);

            double depreciableAmount = purchasePrice - salvagePrice;

            double monthlyDepreciation =
                depreciableAmount / usefulLifeMonths;

            return Math.Min(
                depreciableAmount,
                monthlyDepreciation * elapsedMonths
            );
        }

        public static double CalculateAmortization(
            double purchasePrice,
            double salvagePrice,
            DateTime startDate,
            DateTime expiryDate)
        {
            int totalMonths = Math.Max(
                1,
                ((expiryDate.Year - startDate.Year) * 12)
                + expiryDate.Month - startDate.Month
            );

            int elapsedMonths = Math.Max(
                0,
                ((DateTime.Today.Year - startDate.Year) * 12)
                + DateTime.Today.Month - startDate.Month
            );

            elapsedMonths = Math.Min(elapsedMonths, totalMonths);

            double monthlyAmortization =
                (purchasePrice - salvagePrice) / totalMonths;

            return Math.Min(
                purchasePrice - salvagePrice,
                monthlyAmortization * elapsedMonths
            );
        }

        public static double CalculateAnnualDepreciation(
    double purchasePrice,
    double salvagePrice,
    int usefulLifeMonths)
        {
            if (usefulLifeMonths <= 0)
                throw new ArgumentException("Useful life must be positive.");

            if (purchasePrice < salvagePrice)
                throw new ArgumentException(
                    "Purchase price cannot be less than salvage value."
                );

            double depreciableAmount = purchasePrice - salvagePrice;

            return depreciableAmount / (usefulLifeMonths / 12.0);
        }
    }
}