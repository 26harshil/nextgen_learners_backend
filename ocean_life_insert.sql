-- ============================================================
-- Ocean Life Quiz Insert Script
-- Quiz Title: "Wonders of the Ocean" → Category: Ocean Life (ID 26)
-- Run this on your Render PostgreSQL database
-- ============================================================

CALL public.sp_insertfullquiz(
    'Ocean Life',
    'Fun quizzes about ocean animals for kids aged 5-12',
    'Wonders of the Ocean',
    '[
        {
            "question_text": "Which ocean animal is known for being very playful and making clicking sounds?",
            "image_url": "assets/fish/dolphin.webp",
            "sound_data": null,
            "hint": "It often jumps out of the water to say hello.",
            "fun_fact": "Dolphins have their own names for each other using unique whistles!",
            "options_json": [
                {"option_text": "Dolphin", "is_correct": true},
                {"option_text": "Chicken", "is_correct": false},
                {"option_text": "Lion", "is_correct": false},
                {"option_text": "Butterfly", "is_correct": false}
            ]
        },
        {
            "question_text": "What is the largest animal in the entire world?",
            "image_url": "assets/fish/bluewhale.jpg",
            "sound_data": null,
            "hint": "It lives in the ocean and is a mammal.",
            "fun_fact": "A blue whale''s heart is as big as a bumper car!",
            "options_json": [
                {"option_text": "Blue Whale", "is_correct": true},
                {"option_text": "Cat", "is_correct": false},
                {"option_text": "Dog", "is_correct": false},
                {"option_text": "Ant", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal has eight arms and can spray ink to hide?",
            "image_url": "assets/fish/octopus.webp",
            "sound_data": null,
            "hint": "It is very squishy and smart.",
            "fun_fact": "Octopuses have three hearts and blue blood!",
            "options_json": [
                {"option_text": "Octopus", "is_correct": true},
                {"option_text": "Bird", "is_correct": false},
                {"option_text": "Rabbit", "is_correct": false},
                {"option_text": "Horse", "is_correct": false}
            ]
        },
        {
            "question_text": "Which tiny fish swims upright and has a tail like a monkey?",
            "image_url": "assets/fish/seahorse.avif",
            "sound_data": null,
            "hint": "Its name sounds like a farm animal that runs.",
            "fun_fact": "In seahorses, it is the daddies who carry the babies in a pouch!",
            "options_json": [
                {"option_text": "Seahorse", "is_correct": true},
                {"option_text": "Sheep", "is_correct": false},
                {"option_text": "Cow", "is_correct": false},
                {"option_text": "Pig", "is_correct": false}
            ]
        },
        {
            "question_text": "Which ocean animal has a hard shell and can live for over 100 years?",
            "image_url": "assets/fish/turtle.png",
            "sound_data": null,
            "hint": "It swims with flippers and lays eggs on the beach.",
            "fun_fact": "Sea turtles can hold their breath for several hours underwater!",
            "options_json": [
                {"option_text": "Sea Turtle", "is_correct": true},
                {"option_text": "Squirrel", "is_correct": false},
                {"option_text": "Elephant", "is_correct": false},
                {"option_text": "Monkey", "is_correct": false}
            ]
        },
        {
            "question_text": "Which fish has very sharp teeth and is known as a top predator?",
            "image_url": "assets/fish/shark.webp",
            "sound_data": null,
            "hint": "It has fins and a big dorsal fin that sticks out of the water.",
            "fun_fact": "Sharks don''t have bones; their skeletons are made of cartilage!",
            "options_json": [
                {"option_text": "Shark", "is_correct": true},
                {"option_text": "Spider", "is_correct": false},
                {"option_text": "Worm", "is_correct": false},
                {"option_text": "Goldfish", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal looks like a five-pointed shape and lives on the sea floor?",
            "image_url": "assets/fish/starfish.webp",
            "sound_data": null,
            "hint": "You can see them in the sky at night too.",
            "fun_fact": "If a starfish loses an arm, it can grow a whole new one back!",
            "options_json": [
                {"option_text": "Starfish", "is_correct": true},
                {"option_text": "Frog", "is_correct": false},
                {"option_text": "Kangaroo", "is_correct": false},
                {"option_text": "Bee", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal is orange with white stripes and lived in ''Finding Nemo''?",
            "image_url": "assets/fish/clownfish.webp",
            "sound_data": null,
            "hint": "It lives inside stinging anemones for protection.",
            "fun_fact": "Clownfish are covered in a layer of slime that protects them from stings!",
            "options_json": [
                {"option_text": "Clownfish", "is_correct": true},
                {"option_text": "Giraffe", "is_correct": false},
                {"option_text": "Zebra", "is_correct": false},
                {"option_text": "Tiger", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal has a long, pointed tusk like a unicorn?",
            "image_url": "assets/fish/narwhal.jpg",
            "sound_data": null,
            "hint": "It lives in the cold Arctic waters.",
            "fun_fact": "The tusk is actually a very long tooth that can grow 10 feet long!",
            "options_json": [
                {"option_text": "Narwhal", "is_correct": true},
                {"option_text": "Hamster", "is_correct": false},
                {"option_text": "Parrot", "is_correct": false},
                {"option_text": "Duck", "is_correct": false}
            ]
        },
        {
            "question_text": "Which wobbly animal is see-through and has long stinging tentacles?",
            "image_url": "assets/fish/jellyfish.webp",
            "sound_data": null,
            "hint": "It looks like a floating umbrella made of jelly.",
            "fun_fact": "Jellyfish have lived on Earth longer than dinosaurs!",
            "options_json": [
                {"option_text": "Jellyfish", "is_correct": true},
                {"option_text": "Mouse", "is_correct": false},
                {"option_text": "Panda", "is_correct": false},
                {"option_text": "Owl", "is_correct": false}
            ]
        },
        {
            "question_text": "Which large animal has long tusks and loves to lay on icebergs?",
            "image_url": "assets/fish/walrus.webp",
            "sound_data": null,
            "hint": "It has lots of whiskers and is very big.",
            "fun_fact": "Walruses can change color to bright pink when they are warm!",
            "options_json": [
                {"option_text": "Walrus", "is_correct": true},
                {"option_text": "Snake", "is_correct": false},
                {"option_text": "Goat", "is_correct": false},
                {"option_text": "Donkey", "is_correct": false}
            ]
        },
        {
            "question_text": "Which bird cannot fly but is an amazing ocean swimmer?",
            "image_url": "assets/fish/penguin.jpg",
            "sound_data": null,
            "hint": "It wears a black and white tuxedo.",
            "fun_fact": "Penguins use their wings as flippers to fly underwater!",
            "options_json": [
                {"option_text": "Penguin", "is_correct": true},
                {"option_text": "Bat", "is_correct": false},
                {"option_text": "Eagle", "is_correct": false},
                {"option_text": "Pigeon", "is_correct": false}
            ]
        },
        {
            "question_text": "Which flat fish has a long tail and hides under the sand?",
            "image_url": "assets/fish/stingray.webp",
            "sound_data": null,
            "hint": "It flies through the water like a bird.",
            "fun_fact": "Stingrays are related to sharks because they have no bones!",
            "options_json": [
                {"option_text": "Stingray", "is_correct": true},
                {"option_text": "Tuna", "is_correct": false},
                {"option_text": "Salmon", "is_correct": false},
                {"option_text": "Catfish", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal has big claws called pinchers and walks sideways?",
            "image_url": "assets/fish/crab.webp",
            "sound_data": null,
            "hint": "It has a hard shell and lives in tide pools.",
            "fun_fact": "Crabs smell with their antennae and taste with their feet!",
            "options_json": [
                {"option_text": "Crab", "is_correct": true},
                {"option_text": "Bear", "is_correct": false},
                {"option_text": "Monkey", "is_correct": false},
                {"option_text": "Deer", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal is known as the Sea Cow and is very slow and gentle?",
            "image_url": "assets/fish/manatee.webp",
            "sound_data": null,
            "hint": "It loves to eat sea grass in warm water.",
            "fun_fact": "Manatees are related to elephants!",
            "options_json": [
                {"option_text": "Manatee", "is_correct": true},
                {"option_text": "Rhino", "is_correct": false},
                {"option_text": "Camel", "is_correct": false},
                {"option_text": "Hippo", "is_correct": false}
            ]
        },
        {
            "question_text": "Which big ocean animal is black and white and lives in a group called a pod?",
            "image_url": "assets/fish/orca.webp",
            "sound_data": null,
            "hint": "It is also called a Killer Whale.",
            "fun_fact": "Orcas are actually the largest members of the dolphin family!",
            "options_json": [
                {"option_text": "Orca", "is_correct": true},
                {"option_text": "Wolf", "is_correct": false},
                {"option_text": "Tiger", "is_correct": false},
                {"option_text": "Lion", "is_correct": false}
            ]
        },
        {
            "question_text": "Which ocean creature looks like a long, slippery snake?",
            "image_url": "assets/fish/eel.webp",
            "sound_data": null,
            "hint": "It hides in rocky holes in coral reefs.",
            "fun_fact": "Eels can swim backwards as easily as they swim forwards!",
            "options_json": [
                {"option_text": "Eel", "is_correct": true},
                {"option_text": "Worm", "is_correct": false},
                {"option_text": "Lizard", "is_correct": false},
                {"option_text": "Snail", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal has a very long nose like a sword?",
            "image_url": "assets/fish/swordfish.webp",
            "sound_data": null,
            "hint": "It is one of the fastest fish in the sea.",
            "fun_fact": "Swordfish use their sword to slash and stun their prey!",
            "options_json": [
                {"option_text": "Swordfish", "is_correct": true},
                {"option_text": "Fork", "is_correct": false},
                {"option_text": "Spoon", "is_correct": false},
                {"option_text": "Hammer", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal blows up like a balloon when it gets scared?",
            "image_url": "assets/fish/pufferfish.jpg",
            "sound_data": null,
            "hint": "It is covered in tiny prickles.",
            "fun_fact": "A pufferfish can swallow water or air to grow twice its size!",
            "options_json": [
                {"option_text": "Pufferfish", "is_correct": true},
                {"option_text": "Guppy", "is_correct": false},
                {"option_text": "Goldfish", "is_correct": false},
                {"option_text": "Minnow", "is_correct": false}
            ]
        },
        {
            "question_text": "Which ocean giant has the largest eyes in the world?",
            "image_url": "assets/fish/giantsquid.webp",
            "sound_data": null,
            "hint": "It has 10 arms and lives in the deep, dark ocean.",
            "fun_fact": "A giant squid''s eye can be as big as a dinner plate!",
            "options_json": [
                {"option_text": "Giant Squid", "is_correct": true},
                {"option_text": "Shark", "is_correct": false},
                {"option_text": "Crab", "is_correct": false},
                {"option_text": "Whale", "is_correct": false}
            ]
        },
        {
            "question_text": "Which shark has a very strange head that looks like a tool?",
            "image_url": "assets/fish/hammerheadshark.webp",
            "sound_data": null,
            "hint": "You use this tool to hit nails into wood.",
            "fun_fact": "The wide head helps this shark see all around itself!",
            "options_json": [
                {"option_text": "Hammerhead Shark", "is_correct": true},
                {"option_text": "Sawfish", "is_correct": false},
                {"option_text": "Wrench Shark", "is_correct": false},
                {"option_text": "Drill Shark", "is_correct": false}
            ]
        },
        {
            "question_text": "Which tiny creature lives in a shell and moves from place to place?",
            "image_url": "assets/fish/hermitcrab.webp",
            "sound_data": null,
            "hint": "It has to find a new shell when it grows bigger.",
            "fun_fact": "Hermit crabs often trade shells with each other in long lines!",
            "options_json": [
                {"option_text": "Hermit Crab", "is_correct": true},
                {"option_text": "Clam", "is_correct": false},
                {"option_text": "Turtle", "is_correct": false},
                {"option_text": "Snail", "is_correct": false}
            ]
        },
        {
            "question_text": "What is the name of the place where many colorful fish and corals live together?",
            "image_url": "assets/fish/coralreef.webp",
            "sound_data": null,
            "hint": "It is like a rainforest underwater.",
            "fun_fact": "Coral reefs are actually made by tiny animals called polyps!",
            "options_json": [
                {"option_text": "Coral Reef", "is_correct": true},
                {"option_text": "Swimming Pool", "is_correct": false},
                {"option_text": "Sand Castle", "is_correct": false},
                {"option_text": "Bathtub", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal has whiskers and barks like a dog, but lives in the ocean?",
            "image_url": "assets/fish/sealion.webp",
            "sound_data": null,
            "hint": "They love to balance balls on their noses.",
            "fun_fact": "Sea lions can stay underwater for up to 20 minutes!",
            "options_json": [
                {"option_text": "Sea Lion", "is_correct": true},
                {"option_text": "Cat", "is_correct": false},
                {"option_text": "Pig", "is_correct": false},
                {"option_text": "Rabbit", "is_correct": false}
            ]
        },
        {
            "question_text": "What color is the deep ocean where the sunlight cannot reach?",
            "image_url": null,
            "sound_data": null,
            "hint": "It is the color of the night sky.",
            "fun_fact": "Most of the ocean is completely dark because light can''t go that deep!",
            "options_json": [
                {"option_text": "Pitch Black", "is_correct": true},
                {"option_text": "Rainbow", "is_correct": false},
                {"option_text": "Snow White", "is_correct": false},
                {"option_text": "Bright Yellow", "is_correct": false}
            ]
        }
    ]'::jsonb
);
