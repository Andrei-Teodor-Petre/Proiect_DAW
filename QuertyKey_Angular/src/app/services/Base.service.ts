import { HttpClient, HttpHeaders } from "@angular/common/http";

export class BaseService {
  constructor(protected http: HttpClient){

  }

  setHeaders() : HttpHeaders {
    const headersConfig = {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    };

    return new HttpHeaders(headersConfig);
  }
}
