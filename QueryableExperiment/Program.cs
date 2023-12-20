// See https://aka.ms/new-console-template for more information
using QueryableExperiment;

var data = new CustomQueryable<int>()
    .Where(x => x == 1)
    .Select(x => x)
    .ToList();
;
