import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, Router } from "@angular/router";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Show } from "../models/show";
import { MoviesService } from "../services/movies.service";

@Injectable({
    providedIn: 'root',
})
export class MoviesListResolver implements Resolve<Show[]> {
    constructor(private moviesService: MoviesService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Show[]> {
        console.log("Test movies list")
        let categoryName = route.params['category-name'];
        let categoryId = 0;

        switch(categoryName) {
            case 'action':
                categoryId = this.moviesService.actionMoviesId;
                break;
            case 'comedy':
                categoryId = this.moviesService.comedyMoviesId;
                break;
            case 'drama':
                categoryId = this.moviesService.actionMoviesId;
                break;
            default:
                categoryId = 0;
        }

        if(categoryId == 0) {
            this.router.navigate(['/home']);
        }

        return this.moviesService.getMoviesByGenre(categoryId, 1)
            .pipe(map(movies => {
                return movies;
            }));
    }
}