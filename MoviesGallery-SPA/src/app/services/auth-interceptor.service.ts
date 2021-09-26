import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { environment } from 'src/environments/environment';

export class AuthInterceptorService implements HttpInterceptor {
    apiKey = environment.apiKey;

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const modifiedReq = req.clone({
        headers: req.headers.append('api-key', this.apiKey),
    });

    return next.handle(modifiedReq);
  }
}