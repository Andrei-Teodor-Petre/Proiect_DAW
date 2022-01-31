import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Keyboard } from "src/models/keyboard";
import { Observable } from "rxjs";
import { BaseService } from "./Base.service";


@Injectable()
export class KeyboardService extends BaseService {


  getAllKeyboards(): Observable<Keyboard[]>{
    return this.http.get<Keyboard[]>('https://localhost:7053/Keyboard/List', {headers: this.setHeaders()});
  }
}
