export type CalendarSystem = 'gregory' | 'persian'

export class DateService {
    /**
     * Get localized month names for a specific locale and calendar.
     */
    static getMonthNames(locale: string, calendar: CalendarSystem = 'gregory'): { value: string, label: string }[] {
        const formatter = new Intl.DateTimeFormat(`${locale}-u-ca-${calendar}`, { month: 'long' });
        const months = [];
        
        // We use a fixed date for each month to extract labels. 
        // For Gregorian, 2024 is a leap year, let's use it.
        // For Persian, we also need to be careful.
        // A common trick is to iterate through months of a reference year.
        for (let i = 0; i < 12; i++) {
            const date = calendar === 'persian' 
                ? new Date(Date.UTC(2024, i, 15)) // Approximate
                : new Date(2024, i, 15);
            
            // This is actually tricky because Date constructor is Gregorian.
            // Better approach for Intl:
            const monthLabel = formatter.format(this.getSampleDateForMonth(i, calendar));
            months.push({ value: (i + 1).toString(), label: monthLabel });
        }
        return months;
    }

    private static getSampleDateForMonth(monthIndex: number, calendar: CalendarSystem): Date {
        if (calendar === 'gregory') {
            return new Date(2024, monthIndex, 15);
        } else {
            // Solar Hijri hamal (Month 1) starts around March 21
            // Hamal: March, Sawr: April, Jawza: May, Suratan: June, Asad: July, Sunbulah: August,
            // Mizan: September, Aqrab: October, Qaws: November, Jadi: December, Dalwa: January, Hut: February
            // This mapping is approximate but for labels it works if we use a date in the middle of the month.
            // Accurate mapping requires a library or more complex logic, but Intl.DateTimeFormat 
            // with a specific Date will give the correct label for THAT date's month.
            const baseDates = [
                new Date(2024, 3, 1),  // Hamal (approx March 21) -> April 1 is safely in Hamal
                new Date(2024, 4, 1),  // Sawr
                new Date(2024, 5, 1),  // Jawza
                new Date(2024, 6, 1),  // Suratan
                new Date(2024, 7, 1),  // Asad
                new Date(2024, 8, 1),  // Sunbulah
                new Date(2024, 9, 10), // Mizan (approx Sept 23) -> Oct 10 is in Mizan
                new Date(2024, 10, 10),// Aqrab
                new Date(2024, 11, 10),// Qaws
                new Date(2025, 0, 10), // Jadi
                new Date(2025, 1, 10), // Dalwa
                new Date(2025, 2, 10)  // Hut
            ];
            return baseDates[monthIndex];
        }
    }

    static getYears(start: number, end: number): string[] {
        const years = [];
        for (let i = start; i <= end; i++) {
            years.push(i.toString());
        }
        return years;
    }

    /**
     * Get preferred calendar for a locale
     */
    static getPreferredCalendar(locale: string): CalendarSystem {
        if (locale === 'ps' || locale === 'fa') return 'persian';
        return 'gregory';
    }

    /**
     * Get current month and year for a calendar
     */
    static getCurrentPeriod(calendar: CalendarSystem = 'gregory'): { month: string, year: string } {
        const now = new Date();
        const monthFormatter = new Intl.DateTimeFormat(`en-u-ca-${calendar}`, { month: 'numeric' });
        const yearFormatter = new Intl.DateTimeFormat(`en-u-ca-${calendar}`, { year: 'numeric' });
        
        // Month numeric can be like "1" or "01" or even names in some locales, 
        // but 'en-u-ca-...' usually gives numbers.
        const monthNum = monthFormatter.format(now);
        // Year can be like "2024" or "1403"
        const yearNum = yearFormatter.format(now).replace(/[^0-9]/g, ''); // strip any extra symbols
        
        return { 
            month: monthNum, 
            year: yearNum 
        };
    }
}
