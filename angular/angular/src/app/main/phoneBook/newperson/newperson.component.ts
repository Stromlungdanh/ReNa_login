import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import {
    CreatePersonInput,
    PersonServiceServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { Router } from '@angular/router';

@Component({
    selector: 'app-newperson',
    templateUrl: './newperson.component.html',
    styleUrls: ['./newperson.component.css'],
})
export class NewPersonComponent extends AppComponentBase implements OnInit {
    constructor(
        injector: Injector,
        private personService: PersonServiceServiceProxy,
        private route: Router
    ) {
        super(injector);
    }

    model: CreatePersonInput = new CreatePersonInput();

    addPerson(): void {
        this.personService.createPerson(this.model).subscribe(
            (result) => {
                this.notify.success(this.l('SavedSuccessfully'));
                this.route.navigate(['/app/main/phonebook']);
            },
            (error) => {
                console.error();
            }
        );
    }

    cancelAddPerson(): void {
        this.route.navigate(['/app/main/phonebook']);
    }

    ngOnInit() {}
}
