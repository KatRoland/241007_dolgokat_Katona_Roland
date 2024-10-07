using _241007_dolgokat_Katona_Roland;

List<versenyzo> versenyzok = [];

StreamReader sr = new StreamReader("forras.txt", encoding: System.Text.Encoding.UTF8);

while (!sr.EndOfStream)
{
    versenyzok.Add(new versenyzo(sr.ReadLine()));
}

Console.WriteLine($"4. Feladat: {versenyzok.Count}db versenyző fejezte be a versenyt");

int elitek = versenyzok.Count(p => p.kategoria == "elit");
Console.WriteLine($"5. Feladat: {elitek}db verszenyző van elit kategóriában");

var nok = versenyzok.Where(v => v.nem);
//double noiatlag = (nok.Count()*DateTime.Now.Year - nok.Sum( v => v.szul_ev )) / (double)nok.Count();
double noiatlag = nok.Average(p => DateTime.Now.Year - p.szul_ev);

Console.WriteLine(noiatlag);

double kerekparossz = Math.Round(versenyzok.Sum(v => v.idok["kerekpar"].TotalHours),2);

Console.WriteLine(kerekparossz);

var elitejuniors = versenyzok.Where(v => v.kategoria == "elit junior");
double atlaguszas = elitejuniors.Average(p => p.idok["uszas"].TotalSeconds);
Console.WriteLine(atlaguszas);

var ferfiak = versenyzok.Where(v => !v.nem);
versenyzo leggyorsabb = ferfiak.MinBy(v => v.idok.Skip(1).Sum(x => x.Value.TotalSeconds));
Console.WriteLine(leggyorsabb);

var kategoriak = versenyzok.GroupBy(g => g.kategoria);
foreach (var kategoria in kategoriak)
{
    Console.WriteLine($"{kategoria.Key}: {kategoria.Count()}");
    Console.WriteLine($"Átlagos depóban töltött idő: {kategoria.Average(g => g.idok["elsodepo"].TotalSeconds + g.idok["masodikdepo"].TotalSeconds):0.00}");
}


