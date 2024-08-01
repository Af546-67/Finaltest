// Define the Genre discriminated union
type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

// Define the Director record type
type Director = {
    Name: string
    Movies: int
}

// Define the Movie record type
type Movie = {
    Name: string
    RunLength: int
    Genre: Genre
    Director: Director
    IMDBRating: float
}

// Create example movie and director instances
let exampleDirector = { Name = "Christopher Nolan"; Movies = 10 }
let exampleMovie = { 
    Name = "Inception"
    RunLength = 148
    Genre = Thriller
    Director = exampleDirector
    IMDBRating = 8.8
}

printfn "Movie: %s, Directed by: %s, Genre: %A, IMDB Rating: %.1f" 
    exampleMovie.Name 
    exampleMovie.Director.Name 
    exampleMovie.Genre 
    exampleMovie.IMDBRating

// Create movie instances for the list
let movies = [
    { Name = "CODA"; RunLength = 111; Genre = Drama; Director = { Name = "Sian Heder"; Movies = 23 }; IMDBRating = 8.1 }
    { Name = "Belfast"; RunLength = 98; Genre = Comedy; Director = { Name = "Kenneth Branagh"; Movies = 27 }; IMDBRating = 7.3 }
    { Name = "Don't Look Up"; RunLength = 138; Genre = Comedy; Director = { Name = "Adam McKay"; Movies = 27 }; IMDBRating = 7.2 }
    { Name = "Drive My Car"; RunLength = 179; Genre = Drama; Director = { Name = "Ryusuke Hamaguchi"; Movies = 16 }; IMDBRating = 7.6 }
    { Name = "Dune"; RunLength = 155; Genre = Fantasy; Director = { Name = "Denis Villeneuve"; Movies = 24 }; IMDBRating = 8.1 }
    { Name = "King Richard"; RunLength = 144; Genre = Sport; Director = { Name = "Reinaldo Marcus Green"; Movies = 15 }; IMDBRating = 7.5 }
    { Name = "Licorice Pizza"; RunLength = 133; Genre = Comedy; Director = { Name = "Paul Thomas Anderson"; Movies = 49 }; IMDBRating = 7.4 }
    { Name = "Nightmare Alley"; RunLength = 150; Genre = Thriller; Director = { Name = "Guillermo Del Toro"; Movies = 22 }; IMDBRating = 7.1 }
]

// Filter movies with IMDB rating greater than 7.4
let probableOscarWinners = movies |> List.filter (fun movie -> movie.IMDBRating > 7.4)

// Convert movie run length to hours and minutes format
let runLengthToHoursMinutes runLength =
    let hours = runLength / 60
    let minutes = runLength % 60
    sprintf "%dh %dmin" hours minutes

// Create a list of run lengths in hours and minutes
let runLengthsInHoursMinutes = movies |> List.map (fun movie -> runLengthToHoursMinutes movie.RunLength)

printfn "\nProbable Oscar Winners:"
probableOscarWinners |> List.iter (fun movie -> printfn "%s with rating %.1f" movie.Name movie.IMDBRating)

printfn "\nRun Lengths in Hours and Minutes:"
runLengthsInHoursMinutes |> List.iter (printfn "%s")
