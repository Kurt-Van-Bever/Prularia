UPDATE prulariacom.bestellingen
set annulatie = false
where bestelId = 5;
UPDATE prulariacom.bestellingen
set bestellingsStatusId = 2
where bestelId = 5;
UPDATE prulariacom.bestellingen
set annulatiedatum = NULL
where bestelId = 5;


SELECT * FROM prulariacom.bestellingen;