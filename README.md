# TravelPal

Struktur och analys av projekt

Jag började projektet med att skapa all UI, har lagt till lite efterhand, men det mesta fixades från start, men några funktioner.
Därefter kollade jag på UML-diagramet och fixade alla klasser och kopplingar mellan dem för att få allt på plats för att kunna koda den "riktiga" funktionaliteten.
När allt det var klar så gick jag bara sida för sida och fixade det som skulle göras. Add-Travel var den som tog längst tid men var på grund av packlist och att jag var tvungen att fixa en koppling mellan Travel och User

Strukturen är upplagd precis som UML-diagrammet vi fick med uppgiften. 
En större skillnad finns som är att jag lade till ett User-objekt i Travels klassen. 
Detta var för att koppla ihop User och Travels så man kunde veta vilket User-objekt som skapat Travel. 
Gjorde det enklare att ta bort travel från användarens egen lista, när man som admin tog bort det. 
I övrigt har jag använt strukturen vi fick och tycker jag använt den på rätt sätt. 
Skulle kanske fundera på att göra Travels abstrakt då man inte vill kunna skapa en Travel som inte är worktrip eller vacation, utan bara någon av de två. 
Skulle också ha kunnat vara ett Interface men hade själv valt abstrakt klass då man kanske vill ha lite funktioner som till exempel räkna på dagar för resa i den klassen i stället för i all under, men är inget jag implementerat.

Något som jag funderat på också är om det faktiskt behövdes en Travelslist i TravelManager för alla travels i appen. 
Då alla användare kopplar sina resor till sig själva och det alltid finns en lista med alla users skulle man kunna bara loopa igenom user och travels för att få ut alla. 
Men om det blir en stor app så kommer detta göra att allt blir väldigt mycket långsammare så jag beslutade mig för att fortfarande ha kvar listan.

Passport gjorde jag kanske en liten speciell lösning på när jag gör att det inte går att ta bort eller lägga till en extra, funderade över hur jag skulle göra och beslutade mig att jag hanterade den automatiskt vid skapandet av resor. 
En bug som jag har tänkt på är att resor som redan är gjorda av användare som är från ett EU land och ska till EU land, så är passport required false. 
Men om man sedan ändrar land user kommer ifrån till utanför EU så kommer det inte ändras på de som redan är skapade, men kommer ändras på de som skapas efter ändring. 
Eftersom ändring av land på User var en ”nice to have” feature så har jag inte fixat den buggen, kan också vara en feature att lägga till varifrån man ska åka in i travel och att man kan ändra det i travel details.

Jag har försökt tänka på det mesta som kan gå fel, och hittar själv inga buggar förutom den jag nämnde ovan som kan ändras till en feature. 

Min kod har typ inga kommentarer men hoppas det går att läsa ändå, har försökt göra den läsvänlig utan kommentarer så man ändå förstår vad som händer. 

Har du någon fråga om något så kan jag svara på dem.
