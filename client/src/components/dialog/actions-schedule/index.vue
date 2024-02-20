<template>
   <div class="card flex justify-content-center">
      <Dialog
         v-model:visible="visible"
         :closable="false"
         modal
         :header="titleDialog"
         :style="{ width: '25rem' }"
      >
         <span class="p-text-secondary block mb-5">{{ subtitleDialog }}</span>

         <InputText
            id="id"
            class="hidden"
            :v-model="() => userComputed.id.toString()"
         />
         <div class="flex align-items-center gap-3 mb-3">
            <label
               for="name"
               class="font-semibold w-6rem"
               >Nome</label
            >
            <InputText
               id="name"
               class="flex-auto"
               autocomplete="off"
               v-model="userComputed.name"
            />
         </div>
         <div class="flex align-items-center gap-3 mb-5">
            <label
               for="email"
               class="font-semibold w-6rem"
               >Email</label
            >
            <InputText
               id="email"
               class="flex-auto"
               autocomplete="off"
               v-model="userComputed.email"
            />
         </div>
         <div class="flex align-items-center gap-3 mb-5">
            <label
               for="telephone"
               class="font-semibold w-6rem"
               >Telefone</label
            >
            <InputMask
               id="telephone"
               class="flex-auto"
               mask="(99) 99999-9999"
               v-model="userComputed.telephone"
            />
         </div>
         <div class="flex justify-content-end gap-2">
            <Button
               type="button"
               label="Cancel"
               severity="secondary"
               @click="Cancel()"
            ></Button>

            <Toast />
            <ConfirmPopup></ConfirmPopup>
            <Button
               type="button"
               label="Save"
               @click="ConfirmAction($event)"
            ></Button>
         </div>
      </Dialog>
   </div>
</template>

<script lang="ts" setup>
//#region Import
import { computed } from 'vue';
import { IUser } from '@/types/IUser';
import { ActionsScheduleEnum } from '@/enums/ActionsScheduleEnum';
import {
   NEW_USER_TITLE,
   NEW_USER_SUBTITLE,
   UPDATE_USER_TITLE,
   UPDATE_USER_SUBTITLE,
   MESSAGE_CONFIRM_INSERT,
   REJECT_LABEL_CONFIRM_INSERT,
   ACCEPT_LABEL_CONFIRM_INSERT,
   REJECT_SUMMARY_CONFIRM_INSERT,
   REJECT_DETAIL_CONFIRM_INSERT,
   MESSAGE_CONFIRM_UPDATE,
   REJECT_LABEL_CONFIRM_UPDATE,
   ACCEPT_LABEL_CONFIRM_UPDATE,
   REJECT_SUMMARY_CONFIRM_UPDATE,
   REJECT_DETAIL_CONFIRM_UPDATE,
   REQUIRED_FIELDS_SUMARY,
   REQUIRED_FIELDS_DETAIL
} from '@/const/messages';
import Toast from 'primevue/toast';
import ConfirmPopup from 'primevue/confirmpopup';
import { useConfirm } from 'primevue/useconfirm';
import { useToast } from 'primevue/usetoast';
//#endregion

//#region Props
const props = defineProps<{
   visible: boolean;
   action: ActionsScheduleEnum;
   user: IUser;
}>();
//#endregion

//#region Emits
const emit = defineEmits(['actionSchedule']);
//#endregion

//#region Computed
const userComputed = computed<IUser>((): IUser => props.user);
const visible = computed<boolean>((): boolean => props.visible);
const titleDialog = computed<string>((): string => {
   return props.action === ActionsScheduleEnum.INSERT ? NEW_USER_TITLE : UPDATE_USER_TITLE;
});
const subtitleDialog = computed<string>((): string => {
   return props.action === ActionsScheduleEnum.INSERT ? NEW_USER_SUBTITLE : UPDATE_USER_SUBTITLE;
});
//#endregion

//#region Data
const confirm = useConfirm();
const toast = useToast();
//#endregion

//#region Methods
async function Cancel(): Promise<void> {
   emit('actionSchedule', ActionsScheduleEnum.CANCEL);
}

async function Saved(): Promise<void> {
   emit('actionSchedule', props.action, userComputed.value);
}

async function ConfirmAction(event: any): Promise<void> {
   const checkRequiredFields = await CheckRequiredFields();
   if (!checkRequiredFields) {
      toast.add({ severity: 'error', summary: REQUIRED_FIELDS_SUMARY, detail: REQUIRED_FIELDS_DETAIL, life: 3000 });
      return;
   }

   const message = props.action === ActionsScheduleEnum.INSERT ? MESSAGE_CONFIRM_INSERT : MESSAGE_CONFIRM_UPDATE;
   const rejectLabel = props.action === ActionsScheduleEnum.INSERT ? REJECT_LABEL_CONFIRM_INSERT : REJECT_LABEL_CONFIRM_UPDATE;
   const acceptLabel = props.action === ActionsScheduleEnum.INSERT ? ACCEPT_LABEL_CONFIRM_INSERT : ACCEPT_LABEL_CONFIRM_UPDATE;
   const summaryReject = props.action === ActionsScheduleEnum.INSERT ? REJECT_SUMMARY_CONFIRM_INSERT : REJECT_SUMMARY_CONFIRM_UPDATE;
   const detailReject = props.action === ActionsScheduleEnum.INSERT ? REJECT_DETAIL_CONFIRM_INSERT : REJECT_DETAIL_CONFIRM_UPDATE;

   confirm.require({
      target: event.currentTarget,
      message,
      icon: 'pi pi-info-circle',
      rejectClass: 'p-button-secondary p-button-outlined p-button-sm',
      acceptClass: 'p-button-danger p-button-sm',
      rejectLabel,
      acceptLabel,
      accept: (): void => {
         Saved();
      },
      reject: (): void => {
         toast.add({ severity: 'error', summary: summaryReject, detail: detailReject, life: 3000 });
      }
   });
}

async function CheckRequiredFields(): Promise<boolean> {
   return !userComputed.value.name ||
      !userComputed.value.email ||
      !userComputed.value.email.match(
         /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      ) ||
      !userComputed.value.telephone ||
      userComputed.value.telephone.length < 15
      ? false
      : true;
}
//#endregion
</script>
