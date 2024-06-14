<template>
    <div class="row">
        <div class="col-3">
        </div>

        <div class="col-6">
            <p class="bet-result-title">
                Resultado
            </p>
            <hr>
            <p class="bet-result">{{ Message }}</p>
        </div>
    </div>
</template>

<script>

export default {
    name: 'BetResult',
    props: {
        'Message': String
    }
}
</script>

<style scoped>

</style>