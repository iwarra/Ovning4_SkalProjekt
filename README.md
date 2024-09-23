# Svar p� fr�gor

## 1.
Stacken �r en LIFO-struktur. Den lagrar v�rdetyper.
Heap - data kan lagras och tas bort i vilken ordning som helst. Den lagrar referenstyper. "St�das upp" med hj�lp av Garbage Collector.

## 2.
V�rdetyper �r "primitiva" som kommer fr�n System.ValueType. 
Referenstyper kommer fr�n System.Object och vi kan skapa instanser av dem (som refererar till objektet de �rvde fr�n med hj�lp av en pointer).

## 3.
ReturnValue initierar x och y som heltal (v�rdetyper) och d�rf�r p�verkar inte f�r�ndringar av y v�rdet av x. 
I ReturnValue2-metoden initieras x och y som nya instanser av MyInt-klassen. De pekar d�rf�r p� samma referensobjekt och det �r d�rf�r �ndringar i y �terspeglas i v�rdet av x.


## ExamineList
1. I koden
2.Listans kapacitet �kar n�r alla platser i den underliggande arrayen �r upptaggna.
3.Kapaciteten �kar med 4.
4. Det skulle vara ineffektivt. Listan anv�nder en strategi som kallas dynamisk allokering f�r att hantera minneshantering mer effektivt. 
5. Nej, vi kan anv�nda TrimExcess methoden f�r att minska kapaciteten, eller s�tta den direkt.
6. Om vi vet hur m�nga element vi kommer att ha. S� fast antal elementer

## Examine Stack
1. At anv�nda sig av stacken passar inte i Icas k�n f�r att f�rsta personen skulle beh�va v�nta tills alla var "klara" f�r att ta sig ut.
2. I koden
