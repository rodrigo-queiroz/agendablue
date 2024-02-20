<template>
   <div class="flex flex-column">
      <div class="flex align-items-center justify-content-center">
         <Image
            :src="Logo"
            class="flex align-items-center justify-content-center"
            alt="Logo"
            width="320"
         />
      </div>
      <div class="flex align-items-center justify-content-center">
         <div class="card p-fluid sm:w-12 md:w-12 lg:w-8 xl:w-8 mx-auto px-0">
            <slot></slot>
         </div>
      </div>
      <div class="flex align-items-center justify-content-center">
         <p>Desenvolvido por Rodrigo Queiroz</p>
      </div>
   </div>
</template>

<script lang="ts" setup>
//#region Import
import Logo from '@/assets/img/logo.png';
//#endregion
</script>
