let store = {
	state: {
        bodyEnabled: true,
        openFormButtonEnabled: true,
        addBirdFormEnabled: false,
        selectedBird: null,
		birdsList: []
	},

	setBirdsList(list) {
		this.state = list;
	},

    setSelectedBird(bird) {
        this.state.selectedBird = bird;
    }
};

export default store;
