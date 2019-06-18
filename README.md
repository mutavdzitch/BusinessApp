# BusinessApp
# ASP PROJEKAT (DOKUMENTACIJA)
### Projekat: Business App
### Student: Marko Mutavdžić 125/16

### Opis:
Aplikacija namenjena olaksavanju poslovanja više kompanija koje rade na zajedničkim projektima sa svojim zaposlenima. Dakle, ova aplikacija sadrži više firmi, zaposlenih, projekata kao i zadataka zaposlenih na određenim projektima.

Projekat se sastoji iz dve korisničke aplikacije, **API** i **Web** aplikacije. Preko API-a zaposleni može da se prijavi na određeni projekat, pregleda projekte, kompanije, zadatke, doda novi zadatak na projektu, naznači kada je neki zadatak ili projekat gotov i promeni njegov status. Pokriva sve CRUD operacije nad svim entitetima. API sadrži **Swagger** specifikaciju. Web aplikacija predstavlja admin panel aplikacije, takođe sa svim CRUD operacijama. Moguće vršiti filtriranje i pretragau.


**Zaposleni**/ Employee: Zaposleni pored osnovnih informacija mora da ima zanimanje (poslovni položaj) i kompaniju. Može biti učesnik na više projekata i imati više radnih zadataka na tim projektima.

**Projekat**/ Project: Na jednom projektu može raditi više kompanija, tj. više zaposlenih. Pored imena i opisa projekta mora se znati početak i kraj, ukoliko je završen što nam govori njegov status.

**Zadatak**/ Task: Jedan zadatak može raditi isključivo jedan zaposleni i on kao i projekat ima datume početka, kraja i status.

**Kompanija**/ Company: Kompanija može biti učesnik na više projekata i imati više zaposlenih.

### Dijagram baze podataka:
(Code first pristup)
[Link: Dijagram baze podataka](https://imgur.com/g0QFzQ5)
