import { Component, OnInit } from '@angular/core';
import { KeyboardService } from '../services/keyboard.service';

@Component({
  selector: 'app-keyboard',
  templateUrl: './keyboard.component.html',
  styleUrls: ['./keyboard.component.scss']
})
export class KeyboardComponent implements OnInit {

  constructor(private keyboardService: KeyboardService) { }

  ngOnInit(): void {
    this.keyboardService.getAllKeyboards().subscribe(resp => {
      console.table(resp);
    }, err => {
      //this should be replaced by the notification service
      console.log(err);
    });
  }

}
