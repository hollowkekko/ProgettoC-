1. **Gestione Profilo e Obiettivi**
Il sistema deve permettere la creazione di un profilo personale. Poiché il fabbisogno energetico varia, il profilo deve memorizzare due set di target nutrizionali esatti (calorie, carboidrati, proteine, grassi): un set dedicato esclusivamente ai giorni di allenamento e un set ridotto per i giorni di riposo.

2. **Diario Giornaliero (Daily Log)**
L'applicativo deve permettere di registrare una singola giornata sul calendario. Questa giornata deve contenere la data esatta e un'informazione fondamentale: se si tratta di un giorno di workout o di rest. Questa distinzione determinerà quale set di target nutrizionali il sistema dovrà usare per i calcoli.

3. **Registrazione dei Pasti**
All'interno di una specifica giornata creata nel diario, deve essere possibile aggiungere uno o più pasti. Per ogni pasto registrato (es. colazione, pranzo, cena), il sistema deve salvare la descrizione e l'apporto specifico di macro (carboidrati, proteine, grassi) e calorie.

4. **Tracciamento dell'Allenamento**
Se la giornata è contrassegnata come giorno di allenamento, deve essere possibile associarvi una sessione fisica, registrando informazioni come il nome della routine o la durata.

5. **Logica di Business Attesa (Per i futuri Endpoint)**
Quando un client richiede il riepilogo di una data giornata, l'API dovrà raccogliere tutti i pasti di quel giorno, sommarne i macro e restituire un confronto automatico tra quanto consumato e i target previsti per quel giorno (capendo in automatico se pescare i target da workout o da rest).


# Model
- User
- Day (Date + IsWorkout)
- Meal (DayId + Description + Calories + Carbs + Protein + Fat)
- Workout (DayId + Name + Duration)
# DB
- EF Core + SQLite

# API

