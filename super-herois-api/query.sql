CREATE DATABASE superherois;

USE superherois

CREATE TABLE herois (
  id INT NOT NULL IDENTITY PRIMARY KEY,
  nome VARCHAR(120) NOT NULL,
  nomeheroi VARCHAR(120) NOT NULL,
  datanascimento DATE NOT NULL,
  altura FLOAT NOT NULL,
  peso FLOAT NOT NULL,
)

CREATE TABLE superpoderes (
  id INT NOT NULL IDENTITY PRIMARY KEY,
  superpoder VARCHAR(50) NOT NULL,
  descricao VARCHAR(250),
)

CREATE TABLE heroissuperpoderes (
  heroiid INT NOT NULL,
  superpoderid INT NOT NULL,
  
  CONSTRAINT fk_heroi_id FOREIGN KEY (heroiid) REFERENCES herois(id),
  CONSTRAINT fk_superpoder_id FOREIGN KEY (superpoderid) REFERENCES superpoderes(id)
);
  