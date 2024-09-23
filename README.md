# Svar på frågor

## 1.
Stacken är en LIFO-struktur. Den lagrar värdetyper.
Heap - data kan lagras och tas bort i vilken ordning som helst. Den lagrar referenstyper. "Städas upp" med hjälp av Garbage Collector.

## 2.
Värdetyper är "primitiva" som kommer från System.ValueType. 
Referenstyper kommer från System.Object och vi kan skapa instanser av dem (som refererar till objektet de ärvde från med hjälp av en pointer).

## 3.
ReturnValue initierar x och y som heltal (värdetyper) och därför påverkar inte förändringar av y värdet av x. 
I ReturnValue2-metoden initieras x och y som nya instanser av MyInt-klassen. De pekar därför på samma referensobjekt och det är därför ändringar i y återspeglas i värdet av x.


## ExamineList
1. I koden
2.Listans kapacitet ökar när alla platser i den underliggande arrayen är upptaggna.
3.Kapaciteten ökar med 4.
4. Det skulle vara ineffektivt. Listan använder en strategi som kallas dynamisk allokering för att hantera minneshantering mer effektivt. 
5. Nej, vi kan använda TrimExcess methoden för att minska kapaciteten, eller sätta den direkt.
6. Om vi vet hur många element vi kommer att ha. Så fast antal elementer

## Examine Stack
1. At använda sig av stacken passar inte i Icas kön för att första personen skulle behöva vänta tills alla var "klara" för att ta sig ut.
2. I koden
