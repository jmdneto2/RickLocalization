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
        personagem1Dimensao: this.dataCard.personagem1Dimensao,
        personagem2Dimensao: this.dataCard.personagem2Dimensao,
        personagem1DimensaoId: this.dataCard.personagem1DimensaoId,
        personagem2DimensaoId: this.dataCard.personagem2DimensaoId,
        personagem1Id: this.dataCard.personagem1Id,
        personagem2I2: this.dataCard.personagem2Id,
        personagem1Nome: this.dataCard.personagem1Nome,
        personagem2Nome: this.dataCard.personagem2Nome,

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
    this.dimensaoEscolhidaId = +event.value;
    
  }

  onCancelar(): void {
    this.dialogRef.close();
  }

  onCadastrarViagem(): void {
    this.modalService.postJSON(this.data,this.dimensaoEscolhidaId);
    this.dialogRef.close();
  }

}
