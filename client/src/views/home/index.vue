<template>
   <Layout>
      

    <div class="card">
        <ProgressBar v-if="!refreshTable" mode="indeterminate" style="height: 6px"></ProgressBar>
    </div>

      <DataTable
         v-if="refreshTable"
         v-model:filters="filters"
         v-bind:value="schedule"
         dataKey="id"
         paginator
         :rows="10"
         :loading="loading"
         removableSort
         size="small"
         :globalFilterFields="['name', 'email', 'telephone']"
      >
         <template #header>
            <div class="grid w-full flex justify-content-between flex-wrap">
               <div class="col-3 pl-3 flex align-items-center justify-content-start">
                  <span class="text-primary text-xl text-900 font-bold">Agenda ({{ countProducts }})</span>
               </div>
               <div class="col-6 flex align-items-center justify-content-center px-0">
                  <Button
                     type="button"
                     class="justify-content-center w-10rem mr-2"
                     icon="pi pi-user-plus"
                     label="Adicionar"
                     outlined
                     @click="WhatDialogAction(ActionsScheduleEnum.INSERT, user)"
                  />
                  <IconField iconPosition="left">
                     <InputIcon>
                        <i class="pi pi-search" />
                     </InputIcon>
                     <InputText v-model="filters['global'].value" />
                  </IconField>
               </div>
            </div>
         </template>

         <Column
            field="name"
            header="Nome"
            style="width: 25%"
            sortable
         >
            <template #body="{ data, field }">
               {{ data[field] }}
            </template>
         </Column>
         <Column
            field="email"
            header="Email"
            style="width: 25%"
            sortable
         >
            <template #body="{ data, field }">
               {{ data[field] }}
            </template>
         </Column>
         <Column
            field="telephone"
            header="Telefone"
            style="width: 20%"
            sortable
         >
            <template #body="{ data, field }">
               {{ data[field] }}
            </template>
         </Column>
         <Column>
            <template #body="{ data }">
               <div class="flex align-items-center justify-content-end">
                  <Toast />
                  <ConfirmPopup></ConfirmPopup>
                  <Button
                     icon="pi pi-pencil"
                     outlined
                     rounded
                     class="mr-2"
                     @click="WhatDialogAction(ActionsScheduleEnum.UPDATE, data)"
                  />
                  <Button
                     icon="pi pi-trash"
                     outlined
                     rounded
                     severity="danger"
                     @click="ConfirmRemove($event, data)"
                  />
               </div>
            </template>
         </Column>
      </DataTable>
      <DialogSchedule
         :visible="visibleDialogSchedule"
         :action="actionsSchedule"
         :user="user"
         @actionSchedule="ActionSchedule"
      />
   </Layout>
</template>

<script lang="ts" setup>
//#region Import
import { reactive, ref, onMounted, computed } from 'vue';
import Layout from '@/layouts/default/index.vue';
import DialogSchedule from '@/components/dialog/actions-schedule/index.vue';
import IconField from 'primevue/iconfield';
import InputIcon from 'primevue/inputicon';
import { FilterMatchMode, FilterOperator } from 'primevue/api';
import { ActionsScheduleEnum } from '@/enums/ActionsScheduleEnum';
import { IUser } from '@/types/IUser';
import {
   MESSAGE_CONFIRM_REMOVE,
   REJECT_LABEL_CONFIRM_REMOVE,
   ACCEPT_LABEL_CONFIRM_REMOVE,
   ACCEPT_SUMMARY_CONFIRM_REMOVE,
   ACCEPT_DETAIL_CONFIRM_REMOVE,
   REJECT_SUMMARY_CONFIRM_REMOVE,
   REJECT_DETAIL_CONFIRM_REMOVE,
   ACCEPT_SUMMARY_CONFIRM_INSERT,
   ACCEPT_DETAIL_CONFIRM_INSERT,
   ACCEPT_SUMMARY_CONFIRM_UPDATE,
   ACCEPT_DETAIL_CONFIRM_UPDATE
} from '@/const/messages';
import Toast from 'primevue/toast';
import ConfirmPopup from 'primevue/confirmpopup';
import { useConfirm } from 'primevue/useconfirm';
import { useToast } from 'primevue/usetoast';
// import ScheduleService from '@/service/ScheduleService';
import Schedule_MOCK from '@/service/Schedule_MOCK';
//#endregion

//#region Lifecycle Hooks
onMounted(async () => {
   try {
      schedule.value = await scheduleService.GetAll();
   } catch (error) {
      schedule.value = [ResetUserDefault()];
   }
   loading.value = false;
});
//#endregion

//#region Computed
const countProducts = computed(() => Object.keys(schedule.value).length);
//#endregion

//#region Data
//TODO tirando a conexão com o banco de dados
// const scheduleService: ScheduleService = new ScheduleService();

const scheduleService: Schedule_MOCK = new Schedule_MOCK();
const confirm = useConfirm();
const toast = useToast();

const refreshTable = ref<boolean>(true);
const schedule = ref<IUser[]>([]);
const loading = ref(true);
const visibleDialogSchedule = ref<boolean>(false);
const actionsSchedule = ref<ActionsScheduleEnum>(ActionsScheduleEnum.GET);
const user = ref<IUser>(ResetUserDefault());

const filters = reactive({
   global: { value: null, matchMode: FilterMatchMode.CONTAINS },
   name: { operator: FilterOperator.AND, constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }] },
   email: { operator: FilterOperator.AND, constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }] },
   telephone: { operator: FilterOperator.OR, constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }] }
});
//#endregion

//#region Methods
function ResetUserDefault(): IUser {
   return {
      id: 0,
      name: '',
      email: '',
      telephone: ''
   };
}

async function WhatDialogAction(action: ActionsScheduleEnum, _user: IUser): Promise<void> {
   actionsSchedule.value = action;
   user.value = {
      id: _user.id,
      name: _user.name,
      email: _user.email,
      telephone: _user.telephone
   };
   visibleDialogSchedule.value = true;
}

async function ActionSchedule(_action: ActionsScheduleEnum, _user: IUser): Promise<void> {
   actionsSchedule.value = _action;

   if (_action === ActionsScheduleEnum.CANCEL) {
      visibleDialogSchedule.value = false;
      user.value = ResetUserDefault();
      return;
   }

   switch (_action) {
      case ActionsScheduleEnum.INSERT:
         scheduleService.Insert(_user);
         toast.add({ severity: 'info', summary: ACCEPT_SUMMARY_CONFIRM_INSERT, detail: ACCEPT_DETAIL_CONFIRM_INSERT, life: 3000 });
         break;
      case ActionsScheduleEnum.UPDATE:
         scheduleService.Update(_user);
         toast.add({ severity: 'info', summary: ACCEPT_SUMMARY_CONFIRM_UPDATE, detail: ACCEPT_DETAIL_CONFIRM_UPDATE, life: 3000 });
         break;
      case ActionsScheduleEnum.DELETE:
         scheduleService.Delete(_user);
         toast.add({ severity: 'info', summary: ACCEPT_SUMMARY_CONFIRM_REMOVE, detail: ACCEPT_DETAIL_CONFIRM_REMOVE, life: 3000 });
         break;
   }

   visibleDialogSchedule.value = false;
   user.value = ResetUserDefault();
   loading.value = true;
   
   refreshTable.value = false;
   setTimeout(() => {
      refreshTable.value = true;
   }, 1000);

   schedule.value = scheduleService.GetAll();
   loading.value = false;
}

async function ConfirmRemove(event: any, _user: IUser): Promise<void> {
   confirm.require({
      target: event.currentTarget,
      message: MESSAGE_CONFIRM_REMOVE,
      icon: 'pi pi-info-circle',
      rejectClass: 'p-button-secondary p-button-outlined p-button-sm',
      acceptClass: 'p-button-danger p-button-sm',
      rejectLabel: REJECT_LABEL_CONFIRM_REMOVE,
      acceptLabel: ACCEPT_LABEL_CONFIRM_REMOVE,
      accept: (): void => {
         ActionSchedule(ActionsScheduleEnum.DELETE, _user);
      },
      reject: (): void => {
         toast.add({ severity: 'error', summary: REJECT_SUMMARY_CONFIRM_REMOVE, detail: REJECT_DETAIL_CONFIRM_REMOVE, life: 3000 });
      }
   });
}
//#endregion
</script>
