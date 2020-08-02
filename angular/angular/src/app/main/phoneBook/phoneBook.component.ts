import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PersonListDto,
    UpdatePersonInput,
    PersonServiceServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { TableModule } from 'primeng/components/table/table';
import { result } from 'lodash';

@Component({
    selector: 'app-phoneBook',
    templateUrl: './phoneBook.component.html',
    animations: [appModuleAnimation()],
})
export class PhoneBookComponent extends AppComponentBase implements OnInit {
    people: PersonListDto[] = [];
    filter = '';
    clonePeople: PersonListDto[] = [];
    cloneObject: PersonListDto = new PersonListDto();
    updatePerson: UpdatePersonInput = new UpdatePersonInput();

    constructor(
        injector: Injector,
        private _personService: PersonServiceServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getPeople();
    }

    getPeople(): void {
        this._personService.getPeople(this.filter).subscribe((result) => {
            this.people = result.items;
            this.clonePeople = result.items;
        });
    }

    deletePerson(id: number): void {
        this._personService.deletePerson(id).subscribe(
            (result) => {
                this.notify.success(this.l('DeleteSuccess'));
                this.ngOnInit();
            },
            (error) => {
                console.error();
            }
        );
    }

    onRowEditInit(person: PersonListDto): void {
        this.cloneObject = Object.assign({}, person);
        console.log(this.cloneObject);
    }

    onRowEditSave(person: PersonListDto) {
        if (
            person.name != null &&
            person.surName != null &&
            person.emailAddress != null
        ) {
            this.updatePerson.id = person.id;
            this.updatePerson.name = person.name;
            this.updatePerson.emailAddress = person.emailAddress;
            this.updatePerson.surName = person.surName;
            console.log(this.updatePerson);

            this._personService.updatePerson(this.updatePerson).subscribe(
                (result) => {},
                (error) => {
                    this.notify.error(this.l('Failed'));
                }
            );

            delete this.cloneObject;
            this.notify.success(this.l('Successful'));
        } else {
            this.notify.error(this.l('Failed'));
        }
    }

    onRowEditCancel(person: PersonListDto, index: number) {
        this.clonePeople[index].name = this.cloneObject.name;
        this.clonePeople[index].surName = this.cloneObject.surName;
        this.clonePeople[index].emailAddress = this.cloneObject.emailAddress;
        delete this.cloneObject;
    }
}
