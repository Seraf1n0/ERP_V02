
CREATE TABLE provincia (
  id int NOT NULL,
  codigo int DEFAULT NULL,
  provincia varchar(45) DEFAULT NULL,
  PRIMARY KEY (id)
) 

INSERT INTO provincia (id, codigo, provincia) VALUES ('1', '1', 'San José');
INSERT INTO provincia (id, codigo, provincia) VALUES ('2', '2', 'Alajuela');
INSERT INTO provincia (id, codigo, provincia) VALUES ('3', '3', 'Cartago');
INSERT INTO provincia (id, codigo, provincia) VALUES ('4', '4', 'Heredia');
INSERT INTO provincia (id, codigo, provincia) VALUES ('5', '5', 'Guanacaste');
INSERT INTO provincia (id, codigo, provincia) VALUES ('6', '6', 'Puntarenas');
INSERT INTO provincia (id, codigo, provincia) VALUES ('7', '7', 'Limón');


