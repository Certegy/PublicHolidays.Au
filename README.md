# PublicHolidays.Au [![Build status](https://ci.appveyor.com/api/projects/status/x52hv1rqkvc9fnb7?svg=true)](https://ci.appveyor.com/project/Certegy/publicholidays-au) [![Coverage Status](https://coveralls.io/repos/github/Certegy/PublicHolidays.Au/badge.svg?branch=master)](https://coveralls.io/github/Certegy/PublicHolidays.Au?branch=master) [![NuGet Version](https://img.shields.io/nuget/v/PublicHolidays.Au.svg?style=flat)](https://www.nuget.org/packages/PublicHolidays.Au/)

## Overview

The need for this library came from a business requirement to calculate a date, X number of business days into the future including public holidays.

Traditional approaches to this solving this problem might be a) storing public holidays in a database or configuration file and then reading this information at runtime, b) use of a third party service. Some of the negatives associated to this type of approaches include:
* Accessing a database, configuration file, or third party service is slow.
* Someone needs to remember to update the public holiday data every year.
* Implementing the public holiday business logic is additional code that needs to written and maintained.  
* There is always a chance for data errors.

Looking at the list of Australian and New Zealand public holiday dates, it's soon clear that the date of most of them can be consistently deduced. An application-library/utility to solve this problem is absolutely possible, albiet with a few minor considerations outlined in the next section.

## Exclusions

The calculations for most Australian and New Zealand public holidays is pretty straight forward. However, there are a few cases that need special mention:

* Partial public holidays are not taken into consideration e.g. Chrismas Eve.
* Australian public holidays that are not observed in *most*\* areas/postcodes within a state are excluded e.g. Royal Queensland Show in QLD & other regional public holidays.
* Australian public holidays where the date cannot be consistently deduced have not been implemented e.g. Grand final Eve in VIC & Family & Community Day in ACT.
* Australian public holidays that only apply to specific industries are excluded e.g. Bank Holiday in NSW.

\* A public holiday that is *inclusive* of particluar city/town/postcode should be excluded e.g. Royal Queensland Show in QLD. Alternativly a public holiday that is *exclusive* of particluar city/town/postcode should be included e.g. The Melbourne Cup in VIC where some regions observe the holiday on a differnet day corresponding with their own local racing carnival.

## List of Public Holidays
| Holiday | Regions | Calculation |
| :--- | :--- | :--- |
| New Years Day | ANZ | 1 January - if that date falls on a Saturday the public holiday transfers to the following Monday. If that date falls on a Sunday that day and the following Monday will be public holidays. |
| Day After New Years Day | NZ | 2 January - if that date falls on a Saturday the public holiday transfers to the following Monday. If that date falls on a Sunday or a Monday that day transfers to the following Tuesday. |
| Australia Day | AU | 26 January - if that date falls on a Saturday the public holiday transfers to the following Monday. If that date falls on a Sunday that day and the following Monday will be public holidays. |
| Waitangi Day | NZ | 6 February - if the date falls on a Saturday or Sunday the public holiday transfers to the following Monday. |
| Labour Day | WA | 1st Monday in March. |
| Canberra Day | ACT | 2nd Monday in March. |
| Labour Day* | TAS, VIC | 2nd Monday in March. |
| March public holiday | SA | 2nd Monday in March (currently proclaimed until 2019). |
| Good Friday | ANZ | Varies according to the lunar cycle. |
| Easter Saturday | ACT, NSW, NT, QLD, SA, VIC | Varies according to the lunar cycle. |
| Easter Sunday | ACT, NSW, VIC | Varies according to the lunar cycle. |
| Easter Monday | ANZ | Varies according to the lunar cycle. |
| Easter Tuesday | TAS | Varies according to the lunar cycle. |
| Anzac Day | ANZ | 25 April - if the date falls on a Saturday, the public holiday is observed on that Saturday. If that date falls on a Sunday that day and the following Monday will be public holidays. |
| Labour Day* | NT, QLD | 1st Monday in May. |
| Queen's Birthday | NZ | 1st Monday in June. |
| Western Australia Day | WA | 1st Monday in June. |
| Queen's Birthday** | ACT, NSW, NT, SA, TAS, VIC | 2nd Monday in June. |
| Picnic Day | NT | 1st Monday in August. |
| Family & Community Day | ACT | 1st Monday of 3rd term school holidays. |
| Queen's Birthday | WA | Last Monday in September, or 1st Monday in October (when the last day in September falls on a weekend). |
| Grand Final Eve| VIC | Last Friday in September, or 1st Friday in October. |
| Queen's Birthday | QLD | 1st Monday in October. |
| Labour Day | ACT, NSW, SA | 1st Monday in October. |
| Labour Day | NZ | 4th Monday in October. |
| Melbourne Cup Day | VIC | 1st Tuesday in November. |
| Christmas Day  | ANZ | 25 December - if that date falls on a Saturday the public holiday transfers to the following Monday. If that date falls on a Sunday that day and the following Monday will be public holidays. |
| Boxing Day*** | ANZ | 26 December - if that date falls on a Saturday the public holiday transfers to the following Monday. If that date falls on a Sunday or a Monday that day and the following Tuesday will be public holidays. |

\* Known as May Day in NT and Eight Hours Day in TAS.<br />
\*\* Also known as Volunteer's Day in SA.<br />
\*\*\* Known as Proclamation Day in SA.

## Code
Most of the functionality is accessible via DateTime extension methods for example:
```c#
var nextBusinessDay = DateTime.Now.AddBusinessDays(10);
var nextBusinessDayInSA = DateTime.Now.AddBusinessDays(3, State.SA);
```

## Contributing
Would you be interested in contributing? All PRs are welcome.