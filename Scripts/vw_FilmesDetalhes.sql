-- View: Filmes com Diretor, Atores e Média de Avaliações
CREATE VIEW vw_FilmesDetalhes AS
SELECT f.Id AS FilmeId, f.Titulo, f.AnoLancamento, g.Nome AS Genero, d.Nome AS Diretor,
       GROUP_CONCAT(a.Nome, ', ') AS Atores,
       ROUND(AVG(av.Nota),1) AS MediaNota, COUNT(av.Id) AS TotalAvaliacoes
FROM Filmes f
LEFT JOIN Generos g ON f.GeneroId = g.Id
LEFT JOIN Diretores d ON f.DiretorId = d.Id
LEFT JOIN FilmesAtores fa ON f.Id = fa.FilmeId
LEFT JOIN Atores a ON fa.AtorId = a.Id
LEFT JOIN Avaliacoes av ON f.Id = av.FilmeId
GROUP BY f.Id, f.Titulo, f.AnoLancamento, g.Nome, d.Nome;
