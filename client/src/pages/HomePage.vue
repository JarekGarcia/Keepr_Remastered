<template>
  <div>
    <KeepsCard />
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsServices'
import { AppState } from '../AppState'
import KeepsCard from '../components/KeepsCard.vue'

export default {
  setup() {
    onMounted(() => {
      GetKeeps();
    });

    async function GetKeeps() {
      try {
        await keepsService.GetKeeps();
      } catch (error) {
        Pop.error(error)
      }
    }
    return {
      keeps: computed(() => AppState.keeps),
    }
  },
  components: { KeepsCard }
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
