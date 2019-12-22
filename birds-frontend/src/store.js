let store = {
	state: {
        selectedBird: null,
		birdsList: [
			{
				id: '0',
				name: 'Соловей',
				description: 'Распространён в Европе и Западной Азии (к Востоку до Енисея), к Югу до Северного Кавказа. ' +
                    'Перелётная птица, зимует в Африке. Обитает в сырых кустарниковых зарослях, в долинах рек. Гнёзда на' +
                    ' земле или очень низко в кустах. Питается пауками, насекомыми, червями, ягодами.' +
                    'Перелётная птица, зимует в Африке. Обитает в сырых кустарниковых зарослях, в долинах рек. Гнёзда на' +
                    ' земле или очень низко в кустах. Питается пауками, насекомыми, червями, ягодами.' +
                    'Перелётная птица, зимует в Африке. Обитает в сырых кустарниковых зарослях, в долинах рек. Гнёзда на' +
                    ' земле или очень низко в кустах. Питается пауками, насекомыми, червями, ягодами.' +
                    'Перелётная птица, зимует в Африке. Обитает в сырых кустарниковых зарослях, в долинах рек. Гнёзда на' +
                    ' земле или очень низко в кустах. Питается пауками, насекомыми, червями, ягодами.' +
                    'Перелётная птица, зимует в Африке. Обитает в сырых кустарниковых зарослях, в долинах рек. Гнёзда на' +
                    ' земле или очень низко в кустах. Питается пауками, насекомыми, червями, ягодами.',
				imageUrl: 'http:\/\/s1.fotokto.ru/photo/full/68/680700.jpg',
				audioUrl: 'https:\/\/cdnet4.mixmuz.ru/a2291b06c43a/15f619923177/6972c12a3f6388b47d050371b7aededd-1263de87-11f59afg-1-145b98584bf8/%D0%97%D0%B2%D1%83%D0%BA%D0%B8%20%D0%9F%D1%80%D0%B8%D1%80%D0%BE%D0%B4%D1%8B%20%E2%80%94%20%D0%9F%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%A1%D0%BE%D0%BB%D0%BE%D0%B2%D1%8C%D1%8F.mp3'
			},
			{
				id: '1',
				name: 'Снегирь',
				description: 'Снегири населяют всю Европу, Переднюю Азию, Восточную Азию, включая Сибирь, Камчатку, а также Японию. Снегирь живёт в лесах с густым подлеском, также его можно встретить в садах и парках городов (особенно во время кочёвок). Питается снегирь семенами, почками, некоторыми паукообразными и ягодами (в частности, рябиной).',
				imageUrl: 'https:\/\/avatars.mds.yandex.net/get-pdb/1684047/d3ceb892-da96-432c-89ee-e62e1e797001/s600?webp=false',
				audioUrl: 'https:\/\/cdnet4.mixmuz.ru/a2291b06c43a/15f619923177/6972c12a3f6388b47d050371b7aededd-1263de87-11f59afg-1-145b98584bf8/%D0%97%D0%B2%D1%83%D0%BA%D0%B8%20%D0%9F%D1%80%D0%B8%D1%80%D0%BE%D0%B4%D1%8B%20%E2%80%94%20%D0%9F%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%A1%D0%BE%D0%BB%D0%BE%D0%B2%D1%8C%D1%8F.mp3'
			},
			{
				id: '2',
				name: 'Соловей',
				description: 'Распространён в Европе и Западной Азии (к Востоку до Енисея), к Югу до Северного Кавказа. Перелётная птица, зимует в Африке. Обитает в сырых кустарниковых зарослях, в долинах рек. Гнёзда на земле или очень низко в кустах. Питается пауками, насекомыми, червями, ягодами.',
				imageUrl: 'http:\/\/s1.fotokto.ru/photo/full/68/680700.jpg',
				audioUrl: 'https:\/\/cdnet4.mixmuz.ru/a2291b06c43a/15f619923177/6972c12a3f6388b47d050371b7aededd-1263de87-11f59afg-1-145b98584bf8/%D0%97%D0%B2%D1%83%D0%BA%D0%B8%20%D0%9F%D1%80%D0%B8%D1%80%D0%BE%D0%B4%D1%8B%20%E2%80%94%20%D0%9F%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%A1%D0%BE%D0%BB%D0%BE%D0%B2%D1%8C%D1%8F.mp3'
			},
			{
				id: '3',
				name: 'Снегирь',
				description: 'Снегири населяют всю Европу, Переднюю Азию, Восточную Азию, включая Сибирь, Камчатку, а также Японию. Снегирь живёт в лесах с густым подлеском, также его можно встретить в садах и парках городов (особенно во время кочёвок). Питается снегирь семенами, почками, некоторыми паукообразными и ягодами (в частности, рябиной).',
				imageUrl: 'https:\/\/avatars.mds.yandex.net/get-pdb/1684047/d3ceb892-da96-432c-89ee-e62e1e797001/s600?webp=false',
				audioUrl: 'https:\/\/cdnet4.mixmuz.ru/a2291b06c43a/15f619923177/6972c12a3f6388b47d050371b7aededd-1263de87-11f59afg-1-145b98584bf8/%D0%97%D0%B2%D1%83%D0%BA%D0%B8%20%D0%9F%D1%80%D0%B8%D1%80%D0%BE%D0%B4%D1%8B%20%E2%80%94%20%D0%9F%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%A1%D0%BE%D0%BB%D0%BE%D0%B2%D1%8C%D1%8F.mp3'
			},
			{
				id: '4',
				name: 'Соловей',
				description: 'Распространён в Европе и Западной Азии (к Востоку до Енисея), к Югу до Северного Кавказа. Перелётная птица, зимует в Африке. Обитает в сырых кустарниковых зарослях, в долинах рек. Гнёзда на земле или очень низко в кустах. Питается пауками, насекомыми, червями, ягодами.',
				imageUrl: 'http:\/\/s1.fotokto.ru/photo/full/68/680700.jpg',
				audioUrl: 'https:\/\/cdnet4.mixmuz.ru/a2291b06c43a/15f619923177/6972c12a3f6388b47d050371b7aededd-1263de87-11f59afg-1-145b98584bf8/%D0%97%D0%B2%D1%83%D0%BA%D0%B8%20%D0%9F%D1%80%D0%B8%D1%80%D0%BE%D0%B4%D1%8B%20%E2%80%94%20%D0%9F%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%A1%D0%BE%D0%BB%D0%BE%D0%B2%D1%8C%D1%8F.mp3'
			},
			{
				id: '5',
				name: 'Снегирь',
				description: 'Снегири населяют всю Европу, Переднюю Азию, Восточную Азию, включая Сибирь, Камчатку, а также Японию. Снегирь живёт в лесах с густым подлеском, также его можно встретить в садах и парках городов (особенно во время кочёвок). Питается снегирь семенами, почками, некоторыми паукообразными и ягодами (в частности, рябиной).',
				imageUrl: 'https:\/\/avatars.mds.yandex.net/get-pdb/1684047/d3ceb892-da96-432c-89ee-e62e1e797001/s600?webp=false',
				audioUrl: 'https:\/\/cdnet4.mixmuz.ru/a2291b06c43a/15f619923177/6972c12a3f6388b47d050371b7aededd-1263de87-11f59afg-1-145b98584bf8/%D0%97%D0%B2%D1%83%D0%BA%D0%B8%20%D0%9F%D1%80%D0%B8%D1%80%D0%BE%D0%B4%D1%8B%20%E2%80%94%20%D0%9F%D0%B5%D0%BD%D0%B8%D0%B5%20%D0%A1%D0%BE%D0%BB%D0%BE%D0%B2%D1%8C%D1%8F.mp3'
			}
		]
	},

	setBirdsList(list) {
		this.state = list;
	},

    setSelectedBird(bird) {
        this.state.selectedBird = bird;
    }
};

export default store;
