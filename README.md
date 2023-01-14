# Banken

## Inledning
Detta repo består av en bank-simulator som jag utvecklat för att slipa på mina kunskaper inom objektsorientering och allmäna färdigheter inom C#.

Som användare har man möjlighet att skapa användarkonton och logga in på dessa med användarnamn och lösenord.
Det finns hårdkodade användarkonton i programmet för att kunna genomföra alla funktioner som finns.
Med en lyckad inloggning har man som användare ett löne- och sparkonto angivet till sig själv.

Man kan överföra pengar mellan sina konton och genomföra uttag. Det går att ändra sitt lösenord till sitt användarkonto.

## Struktur
Bank-simulatorn är uppbyggd med större använding av do-while-iterationer och switch-statements.
Detta för att det underlättar för mig som utvecklare att navigera bland koden.

Det finns två klasser i programmet, användarkonton och pengarkonton (för varje användarkonto).
Genom att ha två klasser för de två olika typer av konton gör det lättare för att hålla reda på instanserna av klasserna.
Varje instans av klassen för pengarkonton förvaras i en lista som deklarerats i klassen för användarkonton. 
Detta resulterar i att pengarkontona för varje användarkonto har en sammankoppling. 

## Metodik
Större delar av alla funktioner som programmet består av har fördelats in i sin specifika metod.
Detta underlättar för felsökning och att åtgärda problem då olika funktioner (inlogg, överföring) inte blandas i samma metod.

Metoderna som finns i programmet är:
ImportUsers, PrintStartMenu, PrintUserMenu, ParseRow, AddUser, CreateAccount, LogIn, ChangePassword, TransferMoney och WithdrawMoney.
Vad varje metod gör har kommenterats i koden.

## Reflektioner
Äldre versioner av Banken bestod av användare som hårdkodats i programmet. Det vill säga med användarnamn och lösenord.
Detta gjorde det mycket enklare för mig som utvecklare att konstruera hela programmet. Däremot lärde jag mig inte mycket av det.
Därefter använde jag mig av min lärares metod vilket utgick från att hämta in data från ett text dokument vilket utökade stegen i hantering av datan avsevärt mycket.
Denna data bestod av användarnamn och lösenord men kan uttökas med mer information vilket leder till mer anpassning i stegen av hanteringen.

Tidigare så använde jag mig utav lists istället för arrays för att förvara data inom. Lists är ett mycket bättre alternativ vid hantering av dynamisk data.
Det vill säga, ifall det finns data som ska tas bort, ändras eller uttökas så kan detta göras relativt enkelt med mindre mängd kod.
Innan man slänger sig inpå användningen av Lists så bör man ha bra kunskaper av arrays innan man tar den enkla rutten.
Med denna synpunkt så använde jag mig utav bägge alternativen. Arrays för att lagra datan med användarkonton och Lists för att förvara data om pengarkonton.

Något som kan förbättras i programmet är att implementera en relativ sökväg till textfilen som har all data som importeras.
Detta resulterar i att andra enheter som kör programmet kan hämta in datan utan att behöva anpassa sökvägen.

## Övrigt
För att importera hårdkodade användare så behöver man justera filsökningsvägen till den som finns på din specifika dator.

Om inte detta görs så kommer de hårdkodade användare inte att läsas in i programmet.