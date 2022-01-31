import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { KeyboardService } from "./keyboard.service";

@Injectable()
export class AdminService{

  constructor(private http: HttpClient, private keyboardService: KeyboardService){

  }

  getEntities(){
    var keyboards = this.keyboardService.getAllKeyboards();
    //... this will call the getAll for all the services
  }
}
