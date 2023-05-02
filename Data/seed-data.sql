INSERT INTO Game (
	Name,
	Genre,
	LaunchYear,
	ImageUrl,
	Description,
	UrlSlug
)
VALUES
('Tetris', 'Puzzle', 1984, 'https://media.istockphoto.com/id/1186477254/sv/vektor/byggstenar-tegel-spel-bakgrund-design.jpg?s=1024x1024&w=is&k=20&c=RqNtO7AL5nBfI7ABAPHfWyB2CPaftpooWqksS97_Wis=', 'Tänk snabbt! Klassiskt färglatt pussel-spel', 'tetris'),
('Donkey Kong', 'Adventure', 1981, 'https://live.staticflickr.com/5791/20708744872_7438462ffb_b.jpg', 'Fängslande spel där du är en nära släkting till King Kong, möt "Donkey Kong"!', 'donkey-kong'),
('Street Fighter II', 'Fighting', 1991, 'https://www.spelochsant.se/uploads/images/product_images/281981_original.jpg', 'Bjud in din närmsta vän och se vem som vinner!', 'street-fighter-ii')

INSERT INTO Score (
	Name,
	Year,
	HighScore,
	GameId
) 
VALUES 
('Kalle Anka', '1989', '123456789', 1),
('Kajsa Anka', '1990', '23456788',  1),
('Joakim Anka', '1988', '11112222',  1),
('Musse Pigg', '1991', '22221111',  1),
('Långben', '1989', '123456788', 1),
('Pluto', '1990', '234567890',  1),
('Knatte', '1989', '234234567', 1),
('Fjatte', '1989', '345678912', 1),
('Tjate', '1989', '456789123',  1),
('Luke Skywalker', '1982', '111111111', 2),
('Leia Skywalker', '1983', '111111112', 2),
('Darth Vader', '1983', '222222222', 2),
('Obi-Wan Kenobi', '1984', '333333333', 2),
('Yoda', '1982', '333344444', 2),
('Han Solo', '1982', '222111111',  2),
('Chewbacca', '1984', '555555555',  2),
('Millenium Falcon', '1987', '666666666',  2),
('Jar-Jar Binks', '1988', '222333444',  2),
('C3-PO', '1982', '999999999',  2),
('R2D2', '1988', '888999999',  2),
('Frodo Baggins', '1992', '555555555',  3),
('Samwise Gamgee', '1992', '555555666', 3),
('Gandalf the Grey', '1993', '999999999', 3),
('Gollum', '1994', '777777777', 3),
('Boromir', '1992', '333333222',  3),
('Treebeard', '1992', '000000012', 3),
('Shelob', '1994', '654321987',3),
('Sauron', '1993', '444356789',  3),
('Mordor', '1994', '234567891',  3),
('Saruman', '1996', '888889999',  3)


































