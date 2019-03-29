import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ItemService } from '../Service/item.service';
import { Items } from '../Models/items';
import { OptionsService } from '../Service/options.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {

  public itemForm: FormGroup;
  submitted = false;
  public projects: any;
  selectedProjects: [];
  constructor(private formbuilder: FormBuilder, private itemService: ItemService, private optionsService: OptionsService) {
    this.itemForm = this.formbuilder.group({
      infoName: ['', Validators.required],
      answer: ['', Validators.required]
      // rememberMe : []
    });

    this.GetOptions();
   }

  ngOnInit() {
  }

  Submit() {
    this.submitted = true;

    if (!this.itemForm.valid) {
      return;
    }

    const items = new Items();
    items.Name = this.itemForm.get('infoName').value;
    items.OptionId = this.itemForm.get('answer').value;

    this.itemService.CreateItem(items).subscribe(
      (x: any) => {
        console.log('Created');
        this.itemForm.reset();
      },
        (error: any) => {
          console.error(error);
        }
    );
  }

  onBlurMethod(event: any) {
    this.GetOptions(event.target.value);
  }

  private GetOptions(name: string = null) {
    this.optionsService.GetOptions(name).subscribe(
      (x: any) => {
        this.projects = x;
      },
      (error: any) => {
        console.log(console.error());
      }
      );
  }
}
