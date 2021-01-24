import { Input, OnInit } from '@angular/core';
import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CardModel } from '../shared/models/card.model';
import { ModalService } from './modal.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent {
  @Input() dataCard: CardModel;
  //@Input() dimensaoEscolhida: Input;
  card: CardModel;
  

  constructor(public dialog: MatDialog) { }

  openDialog(): void {    

    const dialogRef = this.dialog.open(ModalBox, {
      width: '250px',
      data: {
        imagemPersonagem1: this.dataCard.imagemPersonagem1,
        imagemPersonagem2: this.dataCard.imagemPersonagem2,
        personagemDimensao1: this.dataCard.personagemDimensao1,
        personagemDimensao2: this.dataCard.personagemDimensao2,
        personagemDimensaoId1: this.dataCard.personagemDimensaoId1,
        personagemDimensaoId2: this.dataCard.personagemDimensaoId2,
        personagemId1: this.dataCard.personagemId1,
        personagemId2: this.dataCard.personagemId2,
        personagemNome1: this.dataCard.personagemNome1,
        personagemNome2: this.dataCard.personagemNome2,

      }     
    });

    dialogRef.afterClosed().subscribe(result => {      
      //this.xxxx = result;
    });
  }

}

@Component({
  selector: 'app-modalbox',
  templateUrl: 'modalbox.html',
})
export class ModalBox {

  dimensaoEscolhidaId: number;

  constructor(
    public dialogRef: MatDialogRef<ModalBox>,
    @Inject(MAT_DIALOG_DATA) public data: CardModel,
    private modalService : ModalService ) { } 

  setValue(event) {
    //console.log(event.value);
    this.dimensaoEscolhidaId = event.value;
    
  }

  onCancelar(): void {
    this.dialogRef.close();
  }

  onCadastrarViagem(): void {
    this.modalService.postJSON(this.data,this.dimensaoEscolhidaId);
    this.dialogRef.close();
  }

}
