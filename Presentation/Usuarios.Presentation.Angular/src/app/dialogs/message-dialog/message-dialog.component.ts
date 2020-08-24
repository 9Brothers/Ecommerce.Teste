declare let $: any;

import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-message-dialog',
  templateUrl: './message-dialog.component.html',
  styleUrls: ['./message-dialog.component.scss']
})
export class MessageDialogComponent implements OnInit {
  
  @Input() title = '';
  @Input() message = '';

  @Output() closed = new EventEmitter();
  
  constructor() { }

  ngOnInit(): void {
    $('#modal-message').on('hide.bs.modal', () => {
      this.closed.emit("");
    });

  }

  close() {
    $('#modal-message').modal('hide');
  }
}
