import { Genre } from "./genre";
import { ProductionCompany } from "./production-company";
import { Season } from "./season";

export interface TVShowDetails {
    id: number,
    title: string,
    voteAverage: number,
    genres: Genre[],
    posterPath: string,
    backdropPath: string,
    overview: string,
    productionCompanies: ProductionCompany[],
    releaseDate: string,
    originCountry: string,
    seasons: Season[]
}