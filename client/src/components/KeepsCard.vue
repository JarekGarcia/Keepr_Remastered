<template>
    <div class="container-fluid">
        <section class="row">
            <div class="col-3 background-img rounded mx-5 mt-5">
                <div class="row">
                    <div class="col-6 vert-flex justify-content-end">
                        <p>whats up</p>
                    </div>
                </div>
            </div>
        </section>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
    setup() {
        return {}
    }
};
</script>


<style lang="scss" scoped>
.background-img {
    background-image: url(https://images.unsplash.com/photo-1706467998026-7afc4abf548c?q=80&w=1987&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
    height: 10rem;
    background-position: center;
    background-size: cover;
}

.vert-flex {
    flex-direction: column-reverse;
    display: flex;
}
</style>