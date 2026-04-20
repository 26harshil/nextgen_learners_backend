-- ============================================================
-- BrightMind Quiz DB - Full Quiz Insertion Script
-- Run this on your Neon PostgreSQL database via the Neon SQL Editor
-- ============================================================

-- STEP 1: Fix sound_data column type (bytea -> text) if not already text
-- This is required for the C# EF Core model to read it as a string
DO $$
BEGIN
    IF EXISTS (
        SELECT 1 FROM information_schema.columns
        WHERE table_name = 'question'
          AND column_name = 'sound_data'
          AND data_type = 'bytea'
    ) THEN
        ALTER TABLE public.question ALTER COLUMN sound_data TYPE TEXT USING encode(sound_data, 'escape');
        RAISE NOTICE 'Converted sound_data from bytea to text';
    ELSE
        RAISE NOTICE 'sound_data is already text type, no change needed';
    END IF;
END;
$$;

-- ============================================================
-- STEP 2: INSERT SOUNDS QUIZ (Quiz ID will be 13)
-- Animal Sounds Quiz
-- ============================================================
CALL public.sp_insertfullquiz(
    'Animal Sounds',
    'Learn to identify animals by the sounds they make!',
    'Animal Sounds',
    '[
        {
            "question_text": "Which animal makes this sound? 🐄 Mooo!",
            "image_url": null,
            "sound_data": null,
            "hint": "This animal gives us milk",
            "fun_fact": "Cows have four stomach compartments to help digest their food!",
            "options_json": [
                {"option_text": "Cow", "is_correct": true},
                {"option_text": "Horse", "is_correct": false},
                {"option_text": "Sheep", "is_correct": false},
                {"option_text": "Pig", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal makes this sound? 🐕 Woof!",
            "image_url": null,
            "sound_data": null,
            "hint": "This is a popular pet",
            "fun_fact": "Dogs can hear sounds 4 times farther away than humans!",
            "options_json": [
                {"option_text": "Dog", "is_correct": true},
                {"option_text": "Cat", "is_correct": false},
                {"option_text": "Fox", "is_correct": false},
                {"option_text": "Wolf", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal makes this sound? 🐱 Meow!",
            "image_url": null,
            "sound_data": null,
            "hint": "This animal loves to purr",
            "fun_fact": "Cats purr at a frequency of 25-50 Hz, which can heal bones!",
            "options_json": [
                {"option_text": "Cat", "is_correct": true},
                {"option_text": "Dog", "is_correct": false},
                {"option_text": "Rabbit", "is_correct": false},
                {"option_text": "Hamster", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal makes this sound? 🐸 Ribbit!",
            "image_url": null,
            "sound_data": null,
            "hint": "This animal jumps and lives near ponds",
            "fun_fact": "Frogs absorb water through their skin — they never drink it!",
            "options_json": [
                {"option_text": "Frog", "is_correct": true},
                {"option_text": "Toad", "is_correct": false},
                {"option_text": "Lizard", "is_correct": false},
                {"option_text": "Turtle", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal makes this sound? 🦁 Roar!",
            "image_url": null,
            "sound_data": null,
            "hint": "This is called the King of the Jungle",
            "fun_fact": "A lion's roar can be heard up to 8 km away!",
            "options_json": [
                {"option_text": "Lion", "is_correct": true},
                {"option_text": "Tiger", "is_correct": false},
                {"option_text": "Bear", "is_correct": false},
                {"option_text": "Cheetah", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal makes this sound? 🐘 Trumpet!",
            "image_url": null,
            "sound_data": null,
            "hint": "This animal has a very long nose",
            "fun_fact": "Elephants use their trunks to drink about 40 litres of water at a time!",
            "options_json": [
                {"option_text": "Elephant", "is_correct": true},
                {"option_text": "Rhinoceros", "is_correct": false},
                {"option_text": "Hippopotamus", "is_correct": false},
                {"option_text": "Giraffe", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal makes this sound? 🐴 Neigh!",
            "image_url": null,
            "sound_data": null,
            "hint": "People ride on this animal",
            "fun_fact": "Horses can sleep both lying down and standing up!",
            "options_json": [
                {"option_text": "Horse", "is_correct": true},
                {"option_text": "Donkey", "is_correct": false},
                {"option_text": "Zebra", "is_correct": false},
                {"option_text": "Cow", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal makes this sound? 🐸 Croak!",
            "image_url": null,
            "sound_data": null,
            "hint": "This amphibian is related to frogs but lives mostly on land",
            "fun_fact": "Toads have dry bumpy skin while frogs have smooth moist skin!",
            "options_json": [
                {"option_text": "Toad", "is_correct": true},
                {"option_text": "Frog", "is_correct": false},
                {"option_text": "Gecko", "is_correct": false},
                {"option_text": "Newt", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal makes this sound? 🐺 Howl!",
            "image_url": null,
            "sound_data": null,
            "hint": "This animal lives in packs",
            "fun_fact": "Wolves howl to communicate with their pack members over long distances!",
            "options_json": [
                {"option_text": "Wolf", "is_correct": true},
                {"option_text": "Dog", "is_correct": false},
                {"option_text": "Fox", "is_correct": false},
                {"option_text": "Coyote", "is_correct": false}
            ]
        },
        {
            "question_text": "Which animal makes this sound? 🐝 Buzz!",
            "image_url": null,
            "sound_data": null,
            "hint": "This insect makes honey",
            "fun_fact": "A honey bee visits about 2 million flowers to make one pound of honey!",
            "options_json": [
                {"option_text": "Bee", "is_correct": true},
                {"option_text": "Wasp", "is_correct": false},
                {"option_text": "Fly", "is_correct": false},
                {"option_text": "Mosquito", "is_correct": false}
            ]
        }
    ]'::JSONB
);

-- ============================================================
-- STEP 3: INSERT ANIMAL HOMES & BABIES QUIZ (Quiz ID 14)
-- ============================================================
CALL public.sp_insertfullquiz(
    'Animal Homes & Babies',
    'Learn what we call baby animals and where they live!',
    'Nature Explorer',
    '[
        {
            "question_text": "What is a baby dog called?",
            "image_url": null,
            "sound_data": null,
            "hint": "It starts with the letter P",
            "fun_fact": "Puppies are born with their eyes and ears closed and open them after 1-2 weeks!",
            "options_json": [
                {"option_text": "Puppy", "is_correct": true},
                {"option_text": "Kitten", "is_correct": false},
                {"option_text": "Cub", "is_correct": false},
                {"option_text": "Foal", "is_correct": false}
            ]
        },
        {
            "question_text": "What is a baby cat called?",
            "image_url": null,
            "sound_data": null,
            "hint": "It starts with the letter K",
            "fun_fact": "Kittens can hear before they can see — their eyes open around day 10!",
            "options_json": [
                {"option_text": "Kitten", "is_correct": true},
                {"option_text": "Puppy", "is_correct": false},
                {"option_text": "Cub", "is_correct": false},
                {"option_text": "Joey", "is_correct": false}
            ]
        },
        {
            "question_text": "Where do birds live?",
            "image_url": null,
            "sound_data": null,
            "hint": "Birds build this from twigs and leaves",
            "fun_fact": "The bald eagle builds the largest nest of any North American bird — up to 4 meters deep!",
            "options_json": [
                {"option_text": "Nest", "is_correct": true},
                {"option_text": "Den", "is_correct": false},
                {"option_text": "Burrow", "is_correct": false},
                {"option_text": "Hive", "is_correct": false}
            ]
        },
        {
            "question_text": "What is a baby horse called?",
            "image_url": null,
            "sound_data": null,
            "hint": "Baby female horses have a special name",
            "fun_fact": "A foal can stand and walk within hours of being born!",
            "options_json": [
                {"option_text": "Foal", "is_correct": true},
                {"option_text": "Cub", "is_correct": false},
                {"option_text": "Calf", "is_correct": false},
                {"option_text": "Lamb", "is_correct": false}
            ]
        },
        {
            "question_text": "Where do bees live?",
            "image_url": null,
            "sound_data": null,
            "hint": "This is made of hexagonal wax cells",
            "fun_fact": "A beehive can contain up to 80,000 bees!",
            "options_json": [
                {"option_text": "Hive", "is_correct": true},
                {"option_text": "Nest", "is_correct": false},
                {"option_text": "Den", "is_correct": false},
                {"option_text": "Lodge", "is_correct": false}
            ]
        },
        {
            "question_text": "What is a baby cow called?",
            "image_url": null,
            "sound_data": null,
            "hint": "You might see them on a farm",
            "fun_fact": "Calves can run within hours of birth to stay with their mothers!",
            "options_json": [
                {"option_text": "Calf", "is_correct": true},
                {"option_text": "Foal", "is_correct": false},
                {"option_text": "Lamb", "is_correct": false},
                {"option_text": "Kid", "is_correct": false}
            ]
        },
        {
            "question_text": "Where do rabbits live?",
            "image_url": null,
            "sound_data": null,
            "hint": "It is an underground tunnel",
            "fun_fact": "A rabbit's burrow is called a warren and can have many tunnels!",
            "options_json": [
                {"option_text": "Burrow", "is_correct": true},
                {"option_text": "Den", "is_correct": false},
                {"option_text": "Nest", "is_correct": false},
                {"option_text": "Hive", "is_correct": false}
            ]
        },
        {
            "question_text": "What is a baby sheep called?",
            "image_url": null,
            "sound_data": null,
            "hint": "This baby is very fluffy and white",
            "fun_fact": "Lambs can recognize their mother's voice just hours after being born!",
            "options_json": [
                {"option_text": "Lamb", "is_correct": true},
                {"option_text": "Kid", "is_correct": false},
                {"option_text": "Calf", "is_correct": false},
                {"option_text": "Foal", "is_correct": false}
            ]
        },
        {
            "question_text": "Where do bears live?",
            "image_url": null,
            "sound_data": null,
            "hint": "Bears sleep here in winter",
            "fun_fact": "Bears in dens can give birth while in a deep sleep during winter!",
            "options_json": [
                {"option_text": "Den", "is_correct": true},
                {"option_text": "Nest", "is_correct": false},
                {"option_text": "Hive", "is_correct": false},
                {"option_text": "Burrow", "is_correct": false}
            ]
        },
        {
            "question_text": "What is a baby kangaroo called?",
            "image_url": null,
            "sound_data": null,
            "hint": "It lives in its mother''s pouch",
            "fun_fact": "A baby kangaroo is only about 2 cm long when born — the size of a grape!",
            "options_json": [
                {"option_text": "Joey", "is_correct": true},
                {"option_text": "Cub", "is_correct": false},
                {"option_text": "Pup", "is_correct": false},
                {"option_text": "Kit", "is_correct": false}
            ]
        }
    ]'::JSONB
);

-- ============================================================
-- STEP 4: INSERT MUSICAL INSTRUMENTS QUIZ (Quiz ID 15)
-- ============================================================
CALL public.sp_insertfullquiz(
    'Musical Instruments',
    'Learn to recognize different instruments by how they look and sound!',
    'The Music Room',
    '[
        {
            "question_text": "Which instrument has black and white keys?",
            "image_url": null,
            "sound_data": null,
            "hint": "You press keys to make music",
            "fun_fact": "A standard piano has 88 keys — 52 white and 36 black!",
            "options_json": [
                {"option_text": "Piano", "is_correct": true},
                {"option_text": "Guitar", "is_correct": false},
                {"option_text": "Violin", "is_correct": false},
                {"option_text": "Trumpet", "is_correct": false}
            ]
        },
        {
            "question_text": "Which instrument has six strings?",
            "image_url": null,
            "sound_data": null,
            "hint": "You pluck or strum its strings",
            "fun_fact": "The guitar is one of the most popular instruments in the world!",
            "options_json": [
                {"option_text": "Guitar", "is_correct": true},
                {"option_text": "Violin", "is_correct": false},
                {"option_text": "Cello", "is_correct": false},
                {"option_text": "Ukulele", "is_correct": false}
            ]
        },
        {
            "question_text": "Which instrument do you blow into to make sound?",
            "image_url": null,
            "sound_data": null,
            "hint": "It is a shiny brass instrument and looks like a tube",
            "fun_fact": "If you unrolled a trumpet, it would be about 2 meters long!",
            "options_json": [
                {"option_text": "Trumpet", "is_correct": true},
                {"option_text": "Drum", "is_correct": false},
                {"option_text": "Harp", "is_correct": false},
                {"option_text": "Piano", "is_correct": false}
            ]
        },
        {
            "question_text": "Which instrument do you hit with sticks?",
            "image_url": null,
            "sound_data": null,
            "hint": "This instrument keeps the beat",
            "fun_fact": "Drums are one of the oldest musical instruments, dating back 8,000 years!",
            "options_json": [
                {"option_text": "Drums", "is_correct": true},
                {"option_text": "Flute", "is_correct": false},
                {"option_text": "Violin", "is_correct": false},
                {"option_text": "Guitar", "is_correct": false}
            ]
        },
        {
            "question_text": "Which instrument uses a bow to make music?",
            "image_url": null,
            "sound_data": null,
            "hint": "It is held under your chin",
            "fun_fact": "A violin bow has about 150 horse hairs on it!",
            "options_json": [
                {"option_text": "Violin", "is_correct": true},
                {"option_text": "Guitar", "is_correct": false},
                {"option_text": "Piano", "is_correct": false},
                {"option_text": "Flute", "is_correct": false}
            ]
        },
        {
            "question_text": "Which instrument is long and thin and you blow across to play?",
            "image_url": null,
            "sound_data": null,
            "hint": "It is a woodwind instrument",
            "fun_fact": "The flute is one of the oldest instruments — ancient flutes have been found that are over 40,000 years old!",
            "options_json": [
                {"option_text": "Flute", "is_correct": true},
                {"option_text": "Clarinet", "is_correct": false},
                {"option_text": "Trumpet", "is_correct": false},
                {"option_text": "Tuba", "is_correct": false}
            ]
        },
        {
            "question_text": "Which instrument is a large stringed instrument that you sit behind?",
            "image_url": null,
            "sound_data": null,
            "hint": "It has a triangular shape and many strings",
            "fun_fact": "A concert harp has 47 strings and 7 pedals!",
            "options_json": [
                {"option_text": "Harp", "is_correct": true},
                {"option_text": "Piano", "is_correct": false},
                {"option_text": "Cello", "is_correct": false},
                {"option_text": "Violin", "is_correct": false}
            ]
        },
        {
            "question_text": "Which instrument is shaped like a tuba but much smaller?",
            "image_url": null,
            "sound_data": null,
            "hint": "It is a small 4-stringed instrument from Hawaii",
            "fun_fact": "The ukulele was brought to Hawaii from Portugal in the 1880s!",
            "options_json": [
                {"option_text": "Ukulele", "is_correct": true},
                {"option_text": "Mandolin", "is_correct": false},
                {"option_text": "Banjo", "is_correct": false},
                {"option_text": "Lute", "is_correct": false}
            ]
        },
        {
            "question_text": "Which instrument makes sound by shaking it?",
            "image_url": null,
            "sound_data": null,
            "hint": "It makes a rattling sound and is used in Latin music",
            "fun_fact": "Maracas are traditionally made from dried gourds filled with seeds or pebbles!",
            "options_json": [
                {"option_text": "Maracas", "is_correct": true},
                {"option_text": "Tambourine", "is_correct": false},
                {"option_text": "Triangle", "is_correct": false},
                {"option_text": "Castanets", "is_correct": false}
            ]
        },
        {
            "question_text": "Which instrument is a keyboard instrument that uses air?",
            "image_url": null,
            "sound_data": null,
            "hint": "You often find it in churches",
            "fun_fact": "The pipe organ is sometimes called the King of Instruments because of its size and power!",
            "options_json": [
                {"option_text": "Organ", "is_correct": true},
                {"option_text": "Piano", "is_correct": false},
                {"option_text": "Harpsichord", "is_correct": false},
                {"option_text": "Accordion", "is_correct": false}
            ]
        }
    ]'::JSONB
);

-- ============================================================
-- STEP 5: INSERT EMOTIONS & FEELINGS QUIZ (Quiz ID 16)
-- ============================================================
CALL public.sp_insertfullquiz(
    'Emotions & Feelings',
    'Learn how to recognize and name your feelings.',
    'How Do You Feel?',
    '[
        {
            "question_text": "How do you feel when you get a birthday present?",
            "image_url": null,
            "sound_data": null,
            "hint": "This feeling makes you smile!",
            "fun_fact": "Smiling uses 12 muscles in your face!",
            "options_json": [
                {"option_text": "Happy", "is_correct": true},
                {"option_text": "Sad", "is_correct": false},
                {"option_text": "Angry", "is_correct": false},
                {"option_text": "Scared", "is_correct": false}
            ]
        },
        {
            "question_text": "How do you feel when you lose your toy?",
            "image_url": null,
            "sound_data": null,
            "hint": "This feeling might make you cry",
            "fun_fact": "Crying can actually help you feel better — it releases stress hormones!",
            "options_json": [
                {"option_text": "Sad", "is_correct": true},
                {"option_text": "Happy", "is_correct": false},
                {"option_text": "Excited", "is_correct": false},
                {"option_text": "Proud", "is_correct": false}
            ]
        },
        {
            "question_text": "How do you feel before going on a fun trip?",
            "image_url": null,
            "sound_data": null,
            "hint": "You can't wait to go!",
            "fun_fact": "Excitement and nervousness cause the same physical reaction in your body!",
            "options_json": [
                {"option_text": "Excited", "is_correct": true},
                {"option_text": "Bored", "is_correct": false},
                {"option_text": "Angry", "is_correct": false},
                {"option_text": "Tired", "is_correct": false}
            ]
        },
        {
            "question_text": "How do you feel when someone takes your toy without asking?",
            "image_url": null,
            "sound_data": null,
            "hint": "This hot feeling makes you want to shout",
            "fun_fact": "Counting to 10 slowly can help calm down feelings of anger!",
            "options_json": [
                {"option_text": "Angry", "is_correct": true},
                {"option_text": "Happy", "is_correct": false},
                {"option_text": "Surprised", "is_correct": false},
                {"option_text": "Calm", "is_correct": false}
            ]
        },
        {
            "question_text": "How do you feel when you see something shocking that you did not expect?",
            "image_url": null,
            "sound_data": null,
            "hint": "Your eyes go wide and your mouth drops open",
            "fun_fact": "When surprised, humans make an involuntary 'O' shape with their mouths!",
            "options_json": [
                {"option_text": "Surprised", "is_correct": true},
                {"option_text": "Bored", "is_correct": false},
                {"option_text": "Sad", "is_correct": false},
                {"option_text": "Tired", "is_correct": false}
            ]
        },
        {
            "question_text": "How do you feel when you are in a dark room alone?",
            "image_url": null,
            "sound_data": null,
            "hint": "You want someone to hold your hand",
            "fun_fact": "Fear of the dark is one of the most common fears in children!",
            "options_json": [
                {"option_text": "Scared", "is_correct": true},
                {"option_text": "Happy", "is_correct": false},
                {"option_text": "Excited", "is_correct": false},
                {"option_text": "Proud", "is_correct": false}
            ]
        },
        {
            "question_text": "How do you feel when you do something really well?",
            "image_url": null,
            "sound_data": null,
            "hint": "You feel great about yourself",
            "fun_fact": "Feeling proud helps motivate you to keep achieving great things!",
            "options_json": [
                {"option_text": "Proud", "is_correct": true},
                {"option_text": "Sad", "is_correct": false},
                {"option_text": "Scared", "is_correct": false},
                {"option_text": "Angry", "is_correct": false}
            ]
        },
        {
            "question_text": "How do you feel when nothing interesting is happening?",
            "image_url": null,
            "sound_data": null,
            "hint": "You might yawn and look for something to do",
            "fun_fact": "Boredom can actually spark creativity — it helps your brain find new ideas!",
            "options_json": [
                {"option_text": "Bored", "is_correct": true},
                {"option_text": "Excited", "is_correct": false},
                {"option_text": "Happy", "is_correct": false},
                {"option_text": "Angry", "is_correct": false}
            ]
        },
        {
            "question_text": "How do you feel when you miss a friend?",
            "image_url": null,
            "sound_data": null,
            "hint": "Your heart feels empty",
            "fun_fact": "Feeling lonely sometimes helps us appreciate the company of friends more!",
            "options_json": [
                {"option_text": "Lonely", "is_correct": true},
                {"option_text": "Happy", "is_correct": false},
                {"option_text": "Excited", "is_correct": false},
                {"option_text": "Surprised", "is_correct": false}
            ]
        },
        {
            "question_text": "How do you feel when you hug your teddy bear?",
            "image_url": null,
            "sound_data": null,
            "hint": "You feel warm inside and everything is okay",
            "fun_fact": "Hugging releases a hormone called oxytocin which makes you feel good!",
            "options_json": [
                {"option_text": "Calm", "is_correct": true},
                {"option_text": "Angry", "is_correct": false},
                {"option_text": "Scared", "is_correct": false},
                {"option_text": "Bored", "is_correct": false}
            ]
        }
    ]'::JSONB
);

-- ============================================================
-- STEP 6: INSERT OPPOSITES QUIZ (Quiz ID 17)
-- ============================================================
CALL public.sp_insertfullquiz(
    'Opposites',
    'Learn about contrasting differences by finding the exact opposite word!',
    'Opposite Day',
    '[
        {
            "question_text": "What is the opposite of HOT?",
            "image_url": null,
            "sound_data": null,
            "hint": "What do you feel when holding ice?",
            "fun_fact": "The coldest temperature ever recorded on Earth was -89.2°C in Antarctica!",
            "options_json": [
                {"option_text": "Cold", "is_correct": true},
                {"option_text": "Warm", "is_correct": false},
                {"option_text": "Cool", "is_correct": false},
                {"option_text": "Wet", "is_correct": false}
            ]
        },
        {
            "question_text": "What is the opposite of BIG?",
            "image_url": null,
            "sound_data": null,
            "hint": "An ant is this compared to an elephant",
            "fun_fact": "The smallest mammal in the world is the bumblebee bat — tinier than your thumb!",
            "options_json": [
                {"option_text": "Small", "is_correct": true},
                {"option_text": "Tall", "is_correct": false},
                {"option_text": "Wide", "is_correct": false},
                {"option_text": "Long", "is_correct": false}
            ]
        },
        {
            "question_text": "What is the opposite of DAY?",
            "image_url": null,
            "sound_data": null,
            "hint": "When the moon comes out",
            "fun_fact": "Some animals like owls and bats are active at night — they are called nocturnal!",
            "options_json": [
                {"option_text": "Night", "is_correct": true},
                {"option_text": "Evening", "is_correct": false},
                {"option_text": "Dusk", "is_correct": false},
                {"option_text": "Dawn", "is_correct": false}
            ]
        },
        {
            "question_text": "What is the opposite of UP?",
            "image_url": null,
            "sound_data": null,
            "hint": "Gravity always pulls things this way",
            "fun_fact": "Gravity on the Moon is 6 times weaker than on Earth — you could jump very high!",
            "options_json": [
                {"option_text": "Down", "is_correct": true},
                {"option_text": "Left", "is_correct": false},
                {"option_text": "Right", "is_correct": false},
                {"option_text": "Back", "is_correct": false}
            ]
        },
        {
            "question_text": "What is the opposite of FAST?",
            "image_url": null,
            "sound_data": null,
            "hint": "A snail moves this way",
            "fun_fact": "A snail can travel about 0.03 mph — it would take a snail 14 days to travel 1 mile!",
            "options_json": [
                {"option_text": "Slow", "is_correct": true},
                {"option_text": "Quick", "is_correct": false},
                {"option_text": "Speedy", "is_correct": false},
                {"option_text": "Heavy", "is_correct": false}
            ]
        },
        {
            "question_text": "What is the opposite of HAPPY?",
            "image_url": null,
            "sound_data": null,
            "hint": "When you cry, you feel this way",
            "fun_fact": "It takes 43 muscles to frown but only 17 to smile — smiling is easier!",
            "options_json": [
                {"option_text": "Sad", "is_correct": true},
                {"option_text": "Angry", "is_correct": false},
                {"option_text": "Scared", "is_correct": false},
                {"option_text": "Tired", "is_correct": false}
            ]
        },
        {
            "question_text": "What is the opposite of OPEN?",
            "image_url": null,
            "sound_data": null,
            "hint": "When you shut a door",
            "fun_fact": "The heaviest door in the world is at Lawrence Berkeley Lab — it weighs 360 tons!",
            "options_json": [
                {"option_text": "Closed", "is_correct": true},
                {"option_text": "Empty", "is_correct": false},
                {"option_text": "Dark", "is_correct": false},
                {"option_text": "Locked", "is_correct": false}
            ]
        },
        {
            "question_text": "What is the opposite of WET?",
            "image_url": null,
            "sound_data": null,
            "hint": "A desert is very this",
            "fun_fact": "The Atacama Desert in Chile is the driest place on Earth — some parts have NEVER had rain!",
            "options_json": [
                {"option_text": "Dry", "is_correct": true},
                {"option_text": "Cold", "is_correct": false},
                {"option_text": "Hot", "is_correct": false},
                {"option_text": "Rough", "is_correct": false}
            ]
        },
        {
            "question_text": "What is the opposite of LIGHT?",
            "image_url": null,
            "sound_data": null,
            "hint": "A feather is light — a rock is...",
            "fun_fact": "The heaviest animal on Earth is the blue whale — it can weigh up to 200 tonnes!",
            "options_json": [
                {"option_text": "Heavy", "is_correct": true},
                {"option_text": "Dark", "is_correct": false},
                {"option_text": "Black", "is_correct": false},
                {"option_text": "Slow", "is_correct": false}
            ]
        },
        {
            "question_text": "What is the opposite of LOUD?",
            "image_url": null,
            "sound_data": null,
            "hint": "You must be this in a library",
            "fun_fact": "A blue whale's call is the loudest sound made by any animal — up to 188 decibels!",
            "options_json": [
                {"option_text": "Quiet", "is_correct": true},
                {"option_text": "Soft", "is_correct": false},
                {"option_text": "Slow", "is_correct": false},
                {"option_text": "Small", "is_correct": false}
            ]
        }
    ]'::JSONB
);

-- ============================================================
-- STEP 7: INSERT WEATHER & SEASONS QUIZ (Quiz ID 18)
-- ============================================================
CALL public.sp_insertfullquiz(
    'Weather and Seasons',
    'Discover the different types of weather and the four seasons!',
    'Weather Watcher',
    '[
        {
            "question_text": "Which season comes after Summer?",
            "image_url": null,
            "sound_data": null,
            "hint": "Leaves change color in this season",
            "fun_fact": "Leaves change color because trees stop making chlorophyll, revealing other pigments!",
            "options_json": [
                {"option_text": "Autumn", "is_correct": true},
                {"option_text": "Winter", "is_correct": false},
                {"option_text": "Spring", "is_correct": false},
                {"option_text": "Monsoon", "is_correct": false}
            ]
        },
        {
            "question_text": "What do we call water falling from clouds?",
            "image_url": null,
            "sound_data": null,
            "hint": "You need an umbrella for this",
            "fun_fact": "Raindrops are not actually teardrop-shaped — they look more like hamburger buns!",
            "options_json": [
                {"option_text": "Rain", "is_correct": true},
                {"option_text": "Snow", "is_correct": false},
                {"option_text": "Hail", "is_correct": false},
                {"option_text": "Fog", "is_correct": false}
            ]
        },
        {
            "question_text": "In which season do flowers bloom?",
            "image_url": null,
            "sound_data": null,
            "hint": "This comes after winter",
            "fun_fact": "Some flowers only bloom for a single day before wilting!",
            "options_json": [
                {"option_text": "Spring", "is_correct": true},
                {"option_text": "Winter", "is_correct": false},
                {"option_text": "Autumn", "is_correct": false},
                {"option_text": "Summer", "is_correct": false}
            ]
        },
        {
            "question_text": "What is frozen rain called?",
            "image_url": null,
            "sound_data": null,
            "hint": "It is white and fluffy and great for making snowmen",
            "fun_fact": "No two snowflakes are exactly alike — each has a unique six-sided pattern!",
            "options_json": [
                {"option_text": "Snow", "is_correct": true},
                {"option_text": "Sleet", "is_correct": false},
                {"option_text": "Frost", "is_correct": false},
                {"option_text": "Hail", "is_correct": false}
            ]
        },
        {
            "question_text": "What do you see in the sky during a thunderstorm?",
            "image_url": null,
            "sound_data": null,
            "hint": "It is a bright flash in the sky",
            "fun_fact": "Lightning strikes the Earth about 100 times every second!",
            "options_json": [
                {"option_text": "Lightning", "is_correct": true},
                {"option_text": "Rainbow", "is_correct": false},
                {"option_text": "Clouds", "is_correct": false},
                {"option_text": "Sunshine", "is_correct": false}
            ]
        },
        {
            "question_text": "Which season is the hottest?",
            "image_url": null,
            "sound_data": null,
            "hint": "You go to the beach in this season",
            "fun_fact": "The hottest temperature ever recorded was 56.7°C in Death Valley, USA in 1913!",
            "options_json": [
                {"option_text": "Summer", "is_correct": true},
                {"option_text": "Spring", "is_correct": false},
                {"option_text": "Autumn", "is_correct": false},
                {"option_text": "Winter", "is_correct": false}
            ]
        },
        {
            "question_text": "What colorful arc appears after rain when the sun shines?",
            "image_url": null,
            "sound_data": null,
            "hint": "It has 7 colors",
            "fun_fact": "A rainbow is actually a full circle, but we can only see the top half from the ground!",
            "options_json": [
                {"option_text": "Rainbow", "is_correct": true},
                {"option_text": "Lightning", "is_correct": false},
                {"option_text": "Aurora", "is_correct": false},
                {"option_text": "Sunset", "is_correct": false}
            ]
        },
        {
            "question_text": "Which season is the coldest?",
            "image_url": null,
            "sound_data": null,
            "hint": "You wear thick coats in this season",
            "fun_fact": "Animals like bears hibernate in winter to save energy when food is scarce!",
            "options_json": [
                {"option_text": "Winter", "is_correct": true},
                {"option_text": "Autumn", "is_correct": false},
                {"option_text": "Spring", "is_correct": false},
                {"option_text": "Summer", "is_correct": false}
            ]
        },
        {
            "question_text": "What do we call a spinning column of wind?",
            "image_url": null,
            "sound_data": null,
            "hint": "It looks like a funnel in the sky",
            "fun_fact": "Tornadoes can spin at up to 300 mph — faster than a racing car!",
            "options_json": [
                {"option_text": "Tornado", "is_correct": true},
                {"option_text": "Hurricane", "is_correct": false},
                {"option_text": "Typhoon", "is_correct": false},
                {"option_text": "Cyclone", "is_correct": false}
            ]
        },
        {
            "question_text": "What causes wind?",
            "image_url": null,
            "sound_data": null,
            "hint": "Wind is moving...",
            "fun_fact": "The strongest wind speed ever recorded was 408 km/h on Barrow Island, Australia!",
            "options_json": [
                {"option_text": "Air", "is_correct": true},
                {"option_text": "Water", "is_correct": false},
                {"option_text": "Clouds", "is_correct": false},
                {"option_text": "Rain", "is_correct": false}
            ]
        }
    ]'::JSONB
);

-- ============================================================
-- STEP 8: INSERT COMMUNITY HELPERS QUIZ (Quiz ID 19)
-- ============================================================
CALL public.sp_insertfullquiz(
    'Community Helpers',
    'Learn about the amazing people who help our communities!',
    'Who Helps Us?',
    '[
        {
            "question_text": "Who helps put out fires?",
            "image_url": null,
            "sound_data": null,
            "hint": "They drive a big red truck",
            "fun_fact": "Firefighters can wear up to 30 kg of gear when fighting a fire!",
            "options_json": [
                {"option_text": "Firefighter", "is_correct": true},
                {"option_text": "Police Officer", "is_correct": false},
                {"option_text": "Doctor", "is_correct": false},
                {"option_text": "Teacher", "is_correct": false}
            ]
        },
        {
            "question_text": "Who helps sick people get better?",
            "image_url": null,
            "sound_data": null,
            "hint": "You visit them at a hospital or clinic",
            "fun_fact": "The first hospitals were built in ancient Rome to treat wounded soldiers!",
            "options_json": [
                {"option_text": "Doctor", "is_correct": true},
                {"option_text": "Firefighter", "is_correct": false},
                {"option_text": "Chef", "is_correct": false},
                {"option_text": "Pilot", "is_correct": false}
            ]
        },
        {
            "question_text": "Who keeps us safe in our neighborhood?",
            "image_url": null,
            "sound_data": null,
            "hint": "They wear a uniform and a badge",
            "fun_fact": "Police officers in Japan bow to people as a sign of respect!",
            "options_json": [
                {"option_text": "Police Officer", "is_correct": true},
                {"option_text": "Farmer", "is_correct": false},
                {"option_text": "Baker", "is_correct": false},
                {"option_text": "Librarian", "is_correct": false}
            ]
        },
        {
            "question_text": "Who teaches children in school?",
            "image_url": null,
            "sound_data": null,
            "hint": "They write on a blackboard",
            "fun_fact": "The world''s longest school day is in Chile — students attend school over 7 hours/day!",
            "options_json": [
                {"option_text": "Teacher", "is_correct": true},
                {"option_text": "Nurse", "is_correct": false},
                {"option_text": "Chef", "is_correct": false},
                {"option_text": "Mechanic", "is_correct": false}
            ]
        },
        {
            "question_text": "Who delivers letters and packages to your home?",
            "image_url": null,
            "sound_data": null,
            "hint": "They carry a mailbag",
            "fun_fact": "The first postal service was created in ancient Persia over 2500 years ago!",
            "options_json": [
                {"option_text": "Postman", "is_correct": true},
                {"option_text": "Farmer", "is_correct": false},
                {"option_text": "Driver", "is_correct": false},
                {"option_text": "Chef", "is_correct": false}
            ]
        },
        {
            "question_text": "Who grows food for us to eat?",
            "image_url": null,
            "sound_data": null,
            "hint": "They work in fields and use tractors",
            "fun_fact": "Farmers produce food for about 155 people each year on average!",
            "options_json": [
                {"option_text": "Farmer", "is_correct": true},
                {"option_text": "Baker", "is_correct": false},
                {"option_text": "Doctor", "is_correct": false},
                {"option_text": "Pilot", "is_correct": false}
            ]
        },
        {
            "question_text": "Who fixes broken pipes and water problems in our homes?",
            "image_url": null,
            "sound_data": null,
            "hint": "They work with pipes and wrenches",
            "fun_fact": "The first indoor plumbing was invented by the ancient Romans over 2000 years ago!",
            "options_json": [
                {"option_text": "Plumber", "is_correct": true},
                {"option_text": "Electrician", "is_correct": false},
                {"option_text": "Carpenter", "is_correct": false},
                {"option_text": "Painter", "is_correct": false}
            ]
        },
        {
            "question_text": "Who helps injured people before they reach the hospital?",
            "image_url": null,
            "sound_data": null,
            "hint": "They arrive in an ambulance",
            "fun_fact": "The first ambulances were used in the 1790s during Napoleon''s wars!",
            "options_json": [
                {"option_text": "Paramedic", "is_correct": true},
                {"option_text": "Doctor", "is_correct": false},
                {"option_text": "Police Officer", "is_correct": false},
                {"option_text": "Firefighter", "is_correct": false}
            ]
        },
        {
            "question_text": "Who takes care of your teeth?",
            "image_url": null,
            "sound_data": null,
            "hint": "They look inside your mouth",
            "fun_fact": "Humans grow 2 sets of teeth — 20 baby teeth and 32 adult teeth!",
            "options_json": [
                {"option_text": "Dentist", "is_correct": true},
                {"option_text": "Doctor", "is_correct": false},
                {"option_text": "Nurse", "is_correct": false},
                {"option_text": "Pharmacist", "is_correct": false}
            ]
        },
        {
            "question_text": "Who flies airplanes?",
            "image_url": null,
            "sound_data": null,
            "hint": "They sit in the cockpit",
            "fun_fact": "Pilots train for thousands of hours before flying a commercial passenger plane!",
            "options_json": [
                {"option_text": "Pilot", "is_correct": true},
                {"option_text": "Driver", "is_correct": false},
                {"option_text": "Captain", "is_correct": false},
                {"option_text": "Engineer", "is_correct": false}
            ]
        }
    ]'::JSONB
);

-- ============================================================
-- STEP 9: INSERT BODY PARTS QUIZ (Quiz ID 20)
-- ============================================================
CALL public.sp_insertfullquiz(
    'Body Parts',
    'Identify and learn about parts of the human body.',
    'All About Me',
    '[
        {
            "question_text": "What do we use to see?",
            "image_url": null,
            "sound_data": null,
            "hint": "They are on your face",
            "fun_fact": "Your eyes can see about 10 million different colors!",
            "options_json": [
                {"option_text": "Eyes", "is_correct": true},
                {"option_text": "Ears", "is_correct": false},
                {"option_text": "Nose", "is_correct": false},
                {"option_text": "Mouth", "is_correct": false}
            ]
        },
        {
            "question_text": "What do we use to hear sounds?",
            "image_url": null,
            "sound_data": null,
            "hint": "You have two of these on the sides of your head",
            "fun_fact": "Human ears never stop working — even when you are asleep!",
            "options_json": [
                {"option_text": "Ears", "is_correct": true},
                {"option_text": "Eyes", "is_correct": false},
                {"option_text": "Hands", "is_correct": false},
                {"option_text": "Feet", "is_correct": false}
            ]
        },
        {
            "question_text": "What do we use to smell flowers?",
            "image_url": null,
            "sound_data": null,
            "hint": "It is in the middle of your face",
            "fun_fact": "Humans can detect over 1 trillion different smells!",
            "options_json": [
                {"option_text": "Nose", "is_correct": true},
                {"option_text": "Mouth", "is_correct": false},
                {"option_text": "Tongue", "is_correct": false},
                {"option_text": "Chin", "is_correct": false}
            ]
        },
        {
            "question_text": "What do we use to eat food?",
            "image_url": null,
            "sound_data": null,
            "hint": "It has lips and teeth",
            "fun_fact": "The average person produces about 1-2 litres of saliva every day!",
            "options_json": [
                {"option_text": "Mouth", "is_correct": true},
                {"option_text": "Nose", "is_correct": false},
                {"option_text": "Ears", "is_correct": false},
                {"option_text": "Eyes", "is_correct": false}
            ]
        },
        {
            "question_text": "What do we use to pick things up?",
            "image_url": null,
            "sound_data": null,
            "hint": "You have 10 fingers on these",
            "fun_fact": "Your hands have 27 bones each — that is more than any other part of your body!",
            "options_json": [
                {"option_text": "Hands", "is_correct": true},
                {"option_text": "Feet", "is_correct": false},
                {"option_text": "Arms", "is_correct": false},
                {"option_text": "Legs", "is_correct": false}
            ]
        },
        {
            "question_text": "What do we use to walk and run?",
            "image_url": null,
            "sound_data": null,
            "hint": "You have two of these below your hips",
            "fun_fact": "The average person walks about 100,000 miles in their lifetime — enough to circle the Earth 4 times!",
            "options_json": [
                {"option_text": "Legs", "is_correct": true},
                {"option_text": "Arms", "is_correct": false},
                {"option_text": "Hands", "is_correct": false},
                {"option_text": "Feet", "is_correct": false}
            ]
        },
        {
            "question_text": "Which organ pumps blood through your body?",
            "image_url": null,
            "sound_data": null,
            "hint": "You can feel it beating in your chest",
            "fun_fact": "Your heart beats about 100,000 times every day!",
            "options_json": [
                {"option_text": "Heart", "is_correct": true},
                {"option_text": "Lungs", "is_correct": false},
                {"option_text": "Brain", "is_correct": false},
                {"option_text": "Stomach", "is_correct": false}
            ]
        },
        {
            "question_text": "Which organ do you use to think?",
            "image_url": null,
            "sound_data": null,
            "hint": "It is inside your head",
            "fun_fact": "Your brain uses about 20% of all the energy your body produces!",
            "options_json": [
                {"option_text": "Brain", "is_correct": true},
                {"option_text": "Heart", "is_correct": false},
                {"option_text": "Stomach", "is_correct": false},
                {"option_text": "Lungs", "is_correct": false}
            ]
        },
        {
            "question_text": "What do you use to breathe?",
            "image_url": null,
            "sound_data": null,
            "hint": "You have two of these in your chest",
            "fun_fact": "Your left lung is slightly smaller than your right to make room for the heart!",
            "options_json": [
                {"option_text": "Lungs", "is_correct": true},
                {"option_text": "Heart", "is_correct": false},
                {"option_text": "Brain", "is_correct": false},
                {"option_text": "Liver", "is_correct": false}
            ]
        },
        {
            "question_text": "What is the largest organ of the human body?",
            "image_url": null,
            "sound_data": null,
            "hint": "You can see and touch it right now",
            "fun_fact": "If you spread out an adult''s skin flat, it would cover about 2 square meters!",
            "options_json": [
                {"option_text": "Skin", "is_correct": true},
                {"option_text": "Liver", "is_correct": false},
                {"option_text": "Stomach", "is_correct": false},
                {"option_text": "Heart", "is_correct": false}
            ]
        }
    ]'::JSONB
);

-- ============================================================
-- STEP 10: INSERT BASIC SHAPES QUIZ (Quiz ID 21)
-- ============================================================
CALL public.sp_insertfullquiz(
    'Basic Shapes',
    'Learn about everyday shapes and geometry basics!',
    'Shape Explorer',
    '[
        {
            "question_text": "How many sides does a triangle have?",
            "image_url": null,
            "sound_data": null,
            "hint": "Count the sides of this shape: △",
            "fun_fact": "The Great Pyramid of Giza has a triangular shape on each of its four sides!",
            "options_json": [
                {"option_text": "3", "is_correct": true},
                {"option_text": "4", "is_correct": false},
                {"option_text": "5", "is_correct": false},
                {"option_text": "2", "is_correct": false}
            ]
        },
        {
            "question_text": "How many sides does a square have?",
            "image_url": null,
            "sound_data": null,
            "hint": "All sides are equal in this shape",
            "fun_fact": "Rubik''s Cube is made of smaller squares put together!",
            "options_json": [
                {"option_text": "4", "is_correct": true},
                {"option_text": "3", "is_correct": false},
                {"option_text": "5", "is_correct": false},
                {"option_text": "6", "is_correct": false}
            ]
        },
        {
            "question_text": "Which shape has no corners or edges?",
            "image_url": null,
            "sound_data": null,
            "hint": "It is perfectly round like a ball",
            "fun_fact": "The Earth is not a perfect sphere — it bulges slightly at the equator!",
            "options_json": [
                {"option_text": "Circle", "is_correct": true},
                {"option_text": "Square", "is_correct": false},
                {"option_text": "Triangle", "is_correct": false},
                {"option_text": "Rectangle", "is_correct": false}
            ]
        },
        {
            "question_text": "A rectangle has how many sides?",
            "image_url": null,
            "sound_data": null,
            "hint": "It looks like a stretched square",
            "fun_fact": "Most books, doors, and phone screens are shaped like rectangles!",
            "options_json": [
                {"option_text": "4", "is_correct": true},
                {"option_text": "3", "is_correct": false},
                {"option_text": "5", "is_correct": false},
                {"option_text": "6", "is_correct": false}
            ]
        },
        {
            "question_text": "Which shape has 5 sides?",
            "image_url": null,
            "sound_data": null,
            "hint": "The US defense building is this shape",
            "fun_fact": "The Pentagon in Washington D.C. is one of the world''s largest office buildings!",
            "options_json": [
                {"option_text": "Pentagon", "is_correct": true},
                {"option_text": "Hexagon", "is_correct": false},
                {"option_text": "Octagon", "is_correct": false},
                {"option_text": "Heptagon", "is_correct": false}
            ]
        },
        {
            "question_text": "How many sides does a hexagon have?",
            "image_url": null,
            "sound_data": null,
            "hint": "Honeybee cells are this shape",
            "fun_fact": "Hexagons are the most efficient packing shape — bees figured this out naturally!",
            "options_json": [
                {"option_text": "6", "is_correct": true},
                {"option_text": "5", "is_correct": false},
                {"option_text": "7", "is_correct": false},
                {"option_text": "8", "is_correct": false}
            ]
        },
        {
            "question_text": "Which shape looks like a diamond standing on its corner?",
            "image_url": null,
            "sound_data": null,
            "hint": "It is used as a symbol on playing cards",
            "fun_fact": "The diamond shape is called a rhombus in mathematics!",
            "options_json": [
                {"option_text": "Diamond", "is_correct": true},
                {"option_text": "Square", "is_correct": false},
                {"option_text": "Rectangle", "is_correct": false},
                {"option_text": "Triangle", "is_correct": false}
            ]
        },
        {
            "question_text": "Which 3D shape is like a ball?",
            "image_url": null,
            "sound_data": null,
            "hint": "A basketball or globe is this shape",
            "fun_fact": "A sphere has the smallest surface area for any given volume — nature loves this shape!",
            "options_json": [
                {"option_text": "Sphere", "is_correct": true},
                {"option_text": "Cube", "is_correct": false},
                {"option_text": "Cone", "is_correct": false},
                {"option_text": "Cylinder", "is_correct": false}
            ]
        },
        {
            "question_text": "Which 3D shape looks like an ice cream cone?",
            "image_url": null,
            "sound_data": null,
            "hint": "It has a circle on the bottom and a point at the top",
            "fun_fact": "Traffic cones and party hats are both cone-shaped!",
            "options_json": [
                {"option_text": "Cone", "is_correct": true},
                {"option_text": "Cylinder", "is_correct": false},
                {"option_text": "Pyramid", "is_correct": false},
                {"option_text": "Sphere", "is_correct": false}
            ]
        },
        {
            "question_text": "How many sides does an octagon have?",
            "image_url": null,
            "sound_data": null,
            "hint": "Stop signs are this shape",
            "fun_fact": "Octopuses have 8 arms — just like an octagon has 8 sides! Both start with ''octo'' meaning 8!",
            "options_json": [
                {"option_text": "8", "is_correct": true},
                {"option_text": "6", "is_correct": false},
                {"option_text": "7", "is_correct": false},
                {"option_text": "9", "is_correct": false}
            ]
        }
    ]'::JSONB
);

-- ============================================================
-- VERIFY: Check all quiz IDs exist after insertion
-- ============================================================
SELECT quiz_id, quiz_title, category_id, created_at
FROM public.quiz
ORDER BY quiz_id;

-- Check question counts per quiz
SELECT q.quiz_id, q.quiz_title, COUNT(qu.question_id) AS question_count
FROM public.quiz q
LEFT JOIN public.question qu ON q.quiz_id = qu.quiz_id
GROUP BY q.quiz_id, q.quiz_title
ORDER BY q.quiz_id;
