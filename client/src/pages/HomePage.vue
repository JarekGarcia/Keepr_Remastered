<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-4">

      </div>
    </section>
  </div>
</template>

<script>
import { onMounted } from 'vue';
import Pop from '../utils/Pop';

export default {
  setup() {
    onMounted(() => {

    });

    async function GetKeeps() {
      try {

      } catch (error) {
        Pop.error(error)
      }
    }
    return {

    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
