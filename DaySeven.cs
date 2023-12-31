﻿using System.Text.RegularExpressions;

namespace AdventOfCode2023;

internal class DaySeven {
	const string _dataSet = "8T64Q 595\r\n79J27 258\r\n88885 88\r\n8933J 444\r\n72527 676\r\n5555T 788\r\n69946 463\r\n572QQ 827\r\n553JQ 932\r\n99T99 567\r\n47Q7Q 112\r\n8J8QQ 186\r\n5K499 862\r\n2837Q 321\r\n55557 310\r\nKAAAA 263\r\nJ4999 783\r\n4QQQ4 961\r\n64464 329\r\n8AQ9K 153\r\n763AK 341\r\nQ3K3Q 353\r\n4TJT6 593\r\nKJ46J 666\r\nAA92Q 176\r\n88555 738\r\n8KJJJ 431\r\n46T35 295\r\n86868 400\r\n884A4 19\r\nQQK44 860\r\n99996 794\r\n6J778 159\r\n45Q9T 763\r\n8AQAQ 39\r\n4JJ2K 764\r\nQ42AT 3\r\n77Q7Q 905\r\n57ATJ 185\r\nQQQJ6 707\r\nTKT2T 115\r\nJK646 951\r\n3KT2K 324\r\n94J64 569\r\nQ278J 998\r\n36QKA 979\r\n89T98 772\r\n55T66 669\r\n62747 161\r\n742TK 264\r\nJ5A2Q 252\r\nJKAJK 455\r\n72777 659\r\n4454T 940\r\nQ2278 479\r\n63K36 53\r\n3K839 512\r\nA5AA5 223\r\nT3332 27\r\nKQ55Q 217\r\n75TT7 706\r\n53555 775\r\n9KK96 348\r\n9A999 984\r\n9TT99 943\r\nTTATJ 906\r\n6964K 711\r\n42452 983\r\n22AA2 241\r\n22282 521\r\n77733 627\r\nKQA47 987\r\n738J7 963\r\nKK2KK 231\r\n22322 709\r\n4T7J6 665\r\nQ6K6A 417\r\n2479K 955\r\n7J22T 861\r\n77A4A 446\r\n8642K 934\r\n25J32 435\r\nA3A3A 883\r\nQQ3JQ 280\r\nK7666 489\r\n2QAQ9 732\r\n85422 976\r\nT3393 322\r\n28888 298\r\nJ9759 608\r\n33438 564\r\nA3KQ4 377\r\n2K6TJ 209\r\nQQ64J 482\r\n8T5T3 815\r\n3K6K6 123\r\n37757 741\r\n555A6 858\r\n5TAAA 12\r\n2225K 965\r\nQ29QQ 355\r\n2277K 62\r\n99932 169\r\n77722 458\r\nQ9444 550\r\nKJ8KK 338\r\n9K99A 238\r\n5Q5Q2 427\r\n7A6A6 675\r\n798AQ 766\r\n386K8 420\r\n88788 681\r\n2K4JK 974\r\n53426 776\r\n46892 884\r\n7Q47T 754\r\n923A4 719\r\n449JQ 506\r\n2Q2Q2 596\r\nK888T 235\r\n6AA6K 232\r\n57T5T 314\r\nT3TA4 171\r\n3QQ4A 581\r\nTAA98 946\r\n75Q8A 170\r\n46A4A 807\r\n36836 539\r\n888T3 515\r\n5KA55 520\r\n92J56 164\r\nQ3J56 1\r\nKAAJ7 499\r\n7QJQ4 196\r\nTTKTK 552\r\nAQ4QA 257\r\n7JTTT 249\r\n7QQ89 268\r\n96998 733\r\n39933 713\r\n44JJ4 603\r\n6877K 206\r\nK224J 450\r\nTTTKJ 38\r\nT7999 22\r\n7T55J 660\r\n66363 61\r\n33363 610\r\nTTAAT 795\r\n36336 739\r\n55255 604\r\n982JJ 146\r\n9ATQ6 313\r\nTT688 293\r\nTT7KT 648\r\n93298 817\r\n7TJ77 288\r\n23J3J 184\r\nJT7T3 132\r\nQ9Q95 430\r\n5554A 14\r\nQAQQA 212\r\nTT33T 538\r\n7A7J7 97\r\nJQ738 968\r\nAKA8K 923\r\nK9988 498\r\nJ424A 481\r\n5AT66 792\r\nQQ444 835\r\n22262 916\r\nTJTTJ 334\r\n77Q47 462\r\n84884 871\r\n959AQ 950\r\n9637J 492\r\nQKQQ3 214\r\n68K6A 13\r\n26624 843\r\nTTTT4 470\r\n48TT5 81\r\nA6AQA 540\r\nTTQ9Q 285\r\nA8AAA 473\r\n88848 900\r\nK779K 688\r\n3QJJ5 852\r\n66T6K 224\r\n55595 720\r\n2222T 784\r\n83QT5 870\r\n6QQQ2 426\r\n44K55 625\r\n4AJ94 472\r\n6A55A 284\r\n85584 43\r\nQ96J2 986\r\nKA5AA 939\r\n62662 74\r\n89277 390\r\n4JKKJ 349\r\n336AA 82\r\nA99A9 477\r\nQ95J9 116\r\nK99K8 108\r\nAKA6A 505\r\n37J92 800\r\nTT98T 15\r\nJA75Q 276\r\n44433 91\r\n93494 684\r\n7A772 220\r\nK6JKA 9\r\n8TT85 685\r\n44448 600\r\n64T6T 484\r\nA3K29 547\r\n4455T 698\r\n932J6 742\r\n57595 198\r\n937QJ 114\r\n69696 423\r\nA3A55 143\r\nK8J4J 25\r\n7AQ64 646\r\n8Q44A 166\r\nJ2AQA 809\r\n9993Q 272\r\nA6JT4 812\r\nK44T4 222\r\nJ5567 577\r\n22244 109\r\nTKTTT 631\r\nQ678K 919\r\nQ9KT3 157\r\n4AJ64 602\r\n7667T 912\r\nA9K35 282\r\n272A2 78\r\nJ887J 113\r\nK9A57 246\r\nJA7A2 915\r\nA3T9A 73\r\n264T4 129\r\nKK777 386\r\nT6665 507\r\nJT2AT 642\r\n66K66 382\r\nJ4666 94\r\n235KQ 966\r\nT3T53 868\r\n3QA4A 584\r\nQQ7QQ 432\r\nJKK6K 37\r\n64594 575\r\n95669 931\r\n37383 366\r\nK9KKJ 563\r\n4Q9T3 970\r\n8688T 180\r\nQ999Q 242\r\n74724 243\r\n6666A 623\r\n66AT6 250\r\n4KA58 451\r\nJ622J 493\r\n2J32T 47\r\nQ4586 859\r\n3393Q 221\r\n9Q55Q 908\r\n66277 121\r\nT7A94 461\r\n8KT58 160\r\nK9K99 989\r\n29292 23\r\n48462 574\r\n6T443 1000\r\n33344 414\r\n22728 964\r\nQ58JQ 680\r\n35K7T 542\r\n5A3QK 673\r\nA5553 453\r\n84Q7T 743\r\n9489J 903\r\nTJT94 5\r\n2925A 195\r\n45954 17\r\nJ6T79 460\r\n6638J 848\r\n977J9 192\r\nAAAJ5 131\r\n3T39T 401\r\n87828 447\r\n9JJK7 651\r\n42552 632\r\nT7TJJ 389\r\nAA75A 274\r\nKA46K 11\r\nQ2Q2Q 55\r\nKJKK3 697\r\n5K3K3 495\r\n84786 21\r\n5J5QQ 413\r\n25755 849\r\n29222 780\r\nJ5A9K 630\r\nK6TA6 863\r\nAKKKJ 395\r\nQ4456 777\r\n547K7 328\r\nQT35K 559\r\nAJAA4 872\r\nKTJ6K 48\r\nTQQTQ 215\r\n22662 768\r\n28547 526\r\n7J77Q 958\r\n2J2JK 42\r\nAK648 691\r\nK6833 716\r\n55J55 888\r\n33322 904\r\n2A6J7 605\r\n58887 586\r\n4J8Q7 621\r\n9A8Q8 824\r\nJQ2T9 356\r\n3TTTT 383\r\nJQQQJ 699\r\n56T3Q 351\r\n22422 879\r\nK25AJ 585\r\n82J66 305\r\nQJQ68 703\r\n96974 189\r\n4JT36 419\r\n84TJ2 549\r\nA95A2 84\r\nKK3KK 724\r\nA5KKA 421\r\nTTTAT 636\r\n2T22K 822\r\n337J7 634\r\n98TT9 770\r\nJ99JJ 167\r\n88454 236\r\nJ2985 405\r\nKQKKK 798\r\n6KQ82 168\r\nAJJ9A 92\r\n95595 150\r\n82943 672\r\n9Q7JA 69\r\n43QJQ 829\r\nA8382 773\r\n332J4 8\r\n7777K 657\r\n9J999 851\r\n35J5J 99\r\nAKQ82 24\r\n59355 658\r\nAAAQA 452\r\n98888 44\r\n77947 476\r\n48222 533\r\nT6666 30\r\nTT4T7 144\r\n3Q8Q8 297\r\nJ3888 309\r\nQJ22A 933\r\n6TQ88 977\r\n23A4J 18\r\n66A5A 262\r\n6T5A5 914\r\n5K9J6 922\r\nQ4Q99 751\r\n3874Q 60\r\nTTKT8 653\r\n7TT7T 126\r\n9J668 364\r\n9ATK2 155\r\n44462 187\r\n85AJA 692\r\nK54J9 594\r\n2TK95 318\r\nQT289 744\r\nAQ45Q 846\r\nK2583 841\r\n55556 837\r\n76662 286\r\n79577 893\r\nK3J47 140\r\nQAT37 644\r\n89QT7 921\r\n3AAAA 379\r\nK49K8 647\r\n7373Q 396\r\n9J5Q8 254\r\n799Q7 85\r\n5J55K 558\r\nTJ254 528\r\nQ5QJQ 207\r\n23223 527\r\nAQ83K 694\r\n9TJ2J 101\r\n9476K 590\r\nTTQ5J 359\r\nA9TQ2 641\r\n2J35Q 519\r\n55522 398\r\n99949 708\r\n94K3K 234\r\n4J884 336\r\n3T32T 633\r\n33J3K 137\r\n8J778 456\r\n8Q57T 726\r\n79975 177\r\nJ37Q2 467\r\nTKKKT 553\r\n47442 992\r\nAT7K3 875\r\n76666 573\r\n424QJ 497\r\n333K8 597\r\nAJTAA 29\r\n89Q26 844\r\n3KK33 723\r\nA9AKJ 138\r\n77555 592\r\n33888 762\r\nT5342 561\r\n75547 190\r\nTT4JT 650\r\n45Q55 818\r\n7J777 935\r\n333TQ 478\r\n566J4 71\r\nT7QTT 854\r\n28558 643\r\n26895 273\r\n8762A 58\r\nJ333J 79\r\n387J4 437\r\nT9926 980\r\n4K425 325\r\n97Q5K 546\r\nQ57K3 898\r\nAA988 579\r\n669JA 678\r\n859J5 701\r\n29992 700\r\nJA66A 141\r\n4J777 440\r\nJ7A7A 816\r\nJQQ96 941\r\n43354 924\r\n66T22 408\r\n49444 865\r\n6KA5A 649\r\nQ5T28 106\r\n77977 352\r\nJ56Q5 31\r\n22656 814\r\nAT333 518\r\n6JTT6 2\r\n99889 838\r\nJAKAK 790\r\n35355 247\r\nT2A82 32\r\n68888 429\r\nQ69T3 944\r\n8688K 72\r\n684K8 337\r\nT9576 385\r\n333A4 674\r\n3T633 994\r\n92JQK 894\r\nA6293 517\r\nKK288 327\r\n373Q4 66\r\nKKJJ8 737\r\n38T67 995\r\nKKJ4K 609\r\n95898 615\r\nAQQA9 802\r\nTT8J7 67\r\n3A438 397\r\nAJAKJ 895\r\n254A2 808\r\nJ9T26 117\r\nAJAAJ 954\r\n94499 847\r\nT8999 836\r\nK4T7J 529\r\n24444 535\r\nJ2222 956\r\n44KA4 45\r\n6A66A 95\r\n52778 856\r\nJKJKK 346\r\nAAJAA 211\r\nJ52J5 103\r\n786JJ 693\r\nQ66J6 876\r\n5353J 511\r\nKK6K6 438\r\nK9Q99 424\r\n948T9 655\r\nK47KK 380\r\n97937 271\r\nKKK4K 617\r\nJ4978 142\r\n7Q848 149\r\n8733J 312\r\n88778 172\r\n6A363 926\r\nKQQ4K 468\r\nAK9Q7 962\r\n9TQ58 436\r\nKJK57 165\r\nKA464 967\r\n8TTQQ 10\r\n7464K 306\r\n558Q7 583\r\n29999 267\r\nQAA82 656\r\nK6A75 760\r\n7775J 442\r\nKJ3K3 332\r\nJQ2T4 128\r\nT9728 350\r\nJ4494 89\r\n498TT 365\r\nAJA4Q 193\r\n666Q4 806\r\n37476 410\r\n896QK 302\r\nKKJ6Q 614\r\n29522 265\r\n5TA48 287\r\nAJ24T 705\r\n76TK2 173\r\nA2749 261\r\nJ9575 433\r\nKQ948 828\r\n59545 952\r\n3AT56 275\r\n664Q8 182\r\n6429T 554\r\nQQ8QQ 406\r\n24AA4 259\r\n5J66J 315\r\n9338Q 981\r\n66637 503\r\nTT888 354\r\n23243 179\r\n6K54J 804\r\n277J3 855\r\n22727 682\r\n3693Q 64\r\n97489 375\r\n57T88 174\r\nTQA36 428\r\nKK5KK 839\r\nQ343Q 589\r\nA2262 628\r\nA9AJA 373\r\n56757 565\r\n3K333 454\r\n96622 233\r\nJJJ8J 370\r\n9KTTT 466\r\nK22JK 702\r\nKKK33 508\r\nT9T9T 715\r\n99595 368\r\nTJT55 485\r\nJ28T8 591\r\nT8768 291\r\nT7K68 845\r\nJ666J 663\r\nQ966J 105\r\nJ3333 360\r\n8AQA3 496\r\nKJTQK 316\r\nKTTT3 372\r\nA259T 181\r\n7777Q 191\r\n78777 911\r\n7A925 208\r\nQAQKQ 930\r\nQ736K 747\r\nK7KTK 920\r\n388T3 982\r\nQ5QQQ 218\r\n49J49 145\r\n23329 219\r\nK97KQ 736\r\n7KQJ7 667\r\n4KJA6 323\r\n422T2 857\r\nKJJKT 746\r\nT7TTT 727\r\nJ552T 304\r\n77TKK 107\r\nK432J 278\r\n9JJ99 988\r\n6Q8A8 283\r\n2A6T8 890\r\n28AA5 601\r\nT662T 721\r\n55J5J 725\r\n4QTQ4 237\r\nTKK4T 175\r\n22682 471\r\nJ8538 343\r\n498J3 910\r\n3T548 850\r\n33868 465\r\nK55K3 151\r\n947KJ 118\r\n3T9A5 281\r\n4T83K 422\r\n22K27 51\r\nJ777J 80\r\nA8579 199\r\nK5AK5 972\r\n77233 867\r\nJ8J88 938\r\n22TJ9 369\r\n757A8 686\r\n93J2Q 758\r\nA79T6 999\r\nJ6KA9 239\r\nJ4444 378\r\nQJJ62 59\r\nJQ6Q3 928\r\nKK888 543\r\nJ636J 4\r\n9AA3A 599\r\n69J6J 582\r\n6JKJK 110\r\nQ77QQ 244\r\nQ7272 866\r\n2346J 689\r\n868J8 892\r\n969J9 500\r\n5T5K5 619\r\n27622 937\r\n99799 901\r\nKK336 205\r\nJ5566 975\r\n2A955 947\r\nTKQ57 52\r\n99995 618\r\n36223 301\r\nT4TT8 90\r\nA99AA 49\r\n29699 969\r\n84QTJ 449\r\n3T99J 801\r\nTQQQQ 96\r\nTTK99 344\r\n2J282 98\r\n7TT79 152\r\nJ7JJ7 480\r\nA288J 393\r\n888J8 411\r\n689K6 294\r\n4T2J4 787\r\nQ3344 307\r\n2A7TA 611\r\n7J86Q 624\r\n69J85 869\r\n37878 771\r\n355QA 292\r\n5757J 357\r\n844Q8 156\r\n8TTTT 416\r\nQK9KQ 299\r\n4A6K5 757\r\n76777 68\r\nK692K 710\r\nQJ853 813\r\n2JJ2J 256\r\n7TTKK 957\r\n9JK9K 56\r\n4A55A 303\r\nK6K22 228\r\n99747 767\r\n6K839 560\r\nJA4TA 248\r\nJA822 459\r\nJ6428 668\r\nKKT9K 677\r\nA7AAA 65\r\n38333 796\r\n664Q3 120\r\nJ7432 36\r\nA356J 111\r\n73Q49 475\r\n86TJ2 899\r\n24442 864\r\n55444 729\r\n7K6K4 753\r\n7269Q 960\r\n77J6J 194\r\n8K694 210\r\n5338J 544\r\nTT99J 745\r\n55T5T 622\r\n33Q33 367\r\n55558 342\r\n737J4 148\r\n6T6J9 613\r\n3AA2T 296\r\n434J6 319\r\n333T3 690\r\n44848 936\r\nA98A9 638\r\n7K254 670\r\n74AJQ 104\r\n69698 266\r\n76477 821\r\nTQJTT 580\r\n4TKK4 909\r\n45555 474\r\n53QQ5 887\r\nQJA3Q 443\r\n94A85 136\r\n3KAAA 913\r\n39999 403\r\nA4J4Q 825\r\n28T5A 874\r\nATTA4 54\r\n43JJ4 226\r\nT9J48 509\r\nK7T23 945\r\nAT2Q8 557\r\n6Q7J4 789\r\nKKK9K 16\r\n93J79 317\r\n79653 200\r\nQ666Q 335\r\nAQ33A 362\r\nA999J 765\r\n5QT47 441\r\nJQQQT 756\r\n9T325 122\r\n4AQ8T 571\r\nTQ342 70\r\n222JK 779\r\nJA443 300\r\nJ7K88 990\r\n646T6 154\r\n95569 842\r\n4J626 384\r\n44KK4 50\r\nJQQQQ 93\r\nAA6AA 735\r\n99888 929\r\n4KK9K 629\r\nA38K2 75\r\nAA2AA 163\r\nQQKQQ 87\r\n8Q56K 578\r\nQK467 740\r\n94329 687\r\n257A6 695\r\nK9929 345\r\n777A7 645\r\nQA9AA 57\r\nKKAAA 959\r\n5T5T9 188\r\n8JTTJ 33\r\n2KKAQ 371\r\n47747 671\r\n28538 202\r\nTJ38A 881\r\n656A5 491\r\n54Q89 134\r\n8Q888 704\r\nAKAKK 415\r\nJ2Q92 524\r\n23859 347\r\n8K7A6 20\r\nJK676 826\r\n555K5 833\r\n9AK54 490\r\nJT658 793\r\n79KQ4 778\r\nJA7K2 229\r\n88883 840\r\n87778 791\r\n799K7 712\r\n4KKKA 487\r\nT6JTT 537\r\nATQK2 76\r\nQ5679 392\r\n7QKQ7 147\r\n8KKKK 568\r\n772J6 363\r\n58545 41\r\nA89KT 696\r\nQ3T86 616\r\nQAK54 289\r\n33334 86\r\n2AAA2 158\r\nA55A5 83\r\nTAAT5 102\r\nQ9673 46\r\n9KKK8 882\r\n6JA46 486\r\n6A254 277\r\nJTTK2 556\r\nJ76Q2 269\r\n9Q888 781\r\nJ4K4K 100\r\nTAATA 488\r\nAA9AA 598\r\n78TQ3 722\r\nA888A 260\r\nT675Q 34\r\nT3T33 761\r\nQ32AQ 35\r\n4QA45 820\r\n87AAA 635\r\nQAA3K 516\r\nJ5543 683\r\n64546 404\r\n74T67 464\r\n3QT3T 731\r\n7TT77 978\r\n7J77K 402\r\nAAKQ4 7\r\n349TA 251\r\n682QA 917\r\n4357T 245\r\n75KT6 183\r\n4QQ54 652\r\n25QK8 358\r\n95KKA 996\r\n66556 407\r\nATTKK 494\r\n666JK 612\r\n3JK5K 290\r\n426J2 522\r\nJA59J 823\r\n5755T 308\r\nJTAQK 831\r\nT52Q9 769\r\n5JKKK 387\r\n8QKKK 333\r\n5K59K 541\r\n44454 942\r\n64625 530\r\nJK7T9 361\r\n2TQQQ 270\r\n42AK6 997\r\n83T87 532\r\n942AQ 785\r\nKAQQK 993\r\n44666 750\r\n43KQ8 418\r\nKJ522 749\r\nJQQ77 953\r\n22J26 119\r\n7TK6Q 531\r\n8TAK6 127\r\n44QQ3 63\r\n63236 853\r\n66A9A 873\r\nK3J3T 805\r\n73373 797\r\n3J336 902\r\nTT67T 896\r\n88KKK 810\r\nKKKQJ 139\r\n69Q58 718\r\n9AKQ5 501\r\n3223J 948\r\n55AJA 588\r\n99K59 434\r\n86568 755\r\nT25AT 897\r\nQ2532 502\r\n38383 388\r\nJ2A98 832\r\n4TA4A 606\r\n32888 730\r\nJ9TJA 545\r\n3328J 339\r\n5TTT5 907\r\nJ3AAJ 819\r\n59459 880\r\n99933 255\r\n3K762 834\r\n9T729 448\r\n58885 376\r\n94449 6\r\nJ7767 374\r\nKKT27 203\r\nQQJQA 133\r\nA4K82 326\r\nTTTK4 803\r\n5789J 661\r\n67633 394\r\nJ37KK 197\r\n55Q57 204\r\n455Q2 562\r\nTQ539 626\r\nJJ222 714\r\nJJJJJ 728\r\n98599 225\r\nK666K 971\r\nQKKK7 878\r\nA8888 664\r\n99JKJ 213\r\nQ332Q 774\r\n5J525 130\r\n77377 786\r\n3KAT4 637\r\n48A9A 891\r\n7K737 409\r\nJ8Q89 525\r\nTT898 877\r\n3Q888 534\r\nJTA8A 886\r\nJ57J8 991\r\n9TKA5 555\r\n76Q27 412\r\n72977 504\r\n488TK 830\r\n2K748 162\r\nT74T9 566\r\nK475J 425\r\nKK62K 889\r\nAJ4TT 510\r\n578KT 124\r\n666J6 570\r\n74968 331\r\n2T265 620\r\n67677 439\r\nAAJ79 949\r\n88339 799\r\nAJQ9A 927\r\nJ34T3 523\r\n929KK 551\r\n2479Q 227\r\nKKJKK 918\r\n85445 201\r\n9Q7J6 536\r\n47454 513\r\nA2A4Q 607\r\nA648J 759\r\nA97A7 514\r\nJ86AA 240\r\nQ6374 576\r\n4J3Q5 26\r\n35A75 178\r\n46KQ4 734\r\n842A2 457\r\nAA4A4 885\r\n724Q5 925\r\n977J8 654\r\nTTT5T 662\r\nJ3339 679\r\n67J67 548\r\nQTJJ6 28\r\nQTAAJ 330\r\nTTJTT 216\r\n7A5A7 483\r\n5JJ8A 973\r\n53AK4 639\r\nKKKJT 640\r\n43825 782\r\nK5KK5 381\r\n7QT77 77\r\n99777 40\r\n777K8 752\r\n2QQ77 811\r\nJ75TQ 320\r\n9K552 445\r\nA65QA 125\r\nQ2379 469\r\n74A98 253\r\n69969 340\r\nQKT84 748\r\nTTQQ7 230\r\n74QJT 985\r\n57757 311\r\nQ7T27 587\r\nQ8Q99 135\r\n6K854 279\r\n3TKAA 717\r\n77484 391\r\nQ2K24 399\r\nQ7QQJ 572";
	const string _testSet = "32T3K 765\r\nT55J5 684\r\nKK677 28\r\nKTJJT 220\r\nQQQJA 483";

	const string _valuesRx = "[2-9AKQJT]";
	const string _fiveOfKindRx = "(" + _valuesRx + @")\1\1\1\1";
	const string _fourOfKindRx = "(" + _valuesRx + @")\1\1\1";
	const string _fullHouseRx = _threeOfKindRx + "(" + _valuesRx + @")\2";
	const string _threeOfKindRx = "(" + _valuesRx + @")\1\1";
	const string _twoPairsRx = "(" + _valuesRx + @")\1" + ".*" + "(" + _valuesRx + @")\2";
	const string _twoOfKindRx = "(" + _valuesRx + @")\1";

	static readonly List<string> _regexes = [_twoOfKindRx, _twoPairsRx, _threeOfKindRx, _fullHouseRx, _fourOfKindRx, _fiveOfKindRx];

	public DaySeven() {
		Console.WriteLine("" + PartOne(_dataSet));
    }

	private static long PartOne(string data) {
		foreach(var i in SortBids(InputToMap(data))) {
			Console.WriteLine(i);
		}

		return SortBids(InputToMap(data)).Select((value, index) => value.Item2 * (index + 1)).Sum();
	}

	private static List<(string, int, int)> InputToMap(string data) {
		List<(string, int, int)> res = [];
		string[] lines = data.Split("\r\n");

		foreach(string line in lines) {
			string[] parts = line.Split(" ");
			res.Add((parts[0], int.Parse(parts[1]), HandToPoints(parts[0])));
		}

		return res;
	}
	
	private static int HandToPoints(string hand) {
		List<char> chars = [..hand];
		chars.Sort();

		for(int i = _regexes.Count - 1; 0 <= i; i--) {
			string line = new(chars.ToArray());
			if (Regex.Match(line, _regexes[i]).Success) {
				return i + 1;
			}
		}

		return 0;
	}

	private static List<(string, int, int)> SortBids(List<(string, int, int)> map) {
		List<(string, int, int)> res = [];
		bool sorted = false;

		res = [..map];

		while (!sorted) {
			sorted = true;
			for(int i = 0; i < res.Count - 1; i++) {
				if (res[i].Item3 > res[i + 1].Item3 || (res[i].Item3 == res[i + 1].Item3 && CompareHand(res[i].Item1, res[i + 1].Item1) == 1)) {
					(res[i], res[i + 1]) = (res[i + 1], res[i]);
					sorted = false;
				}
			}
		}

		return res;
	}

	// 250479810
	// 

	private static int CompareHand(string h1, string h2) {
		// returns 1 if h1 is greater
		// return -1 if h2 is greater

		for(int i = 0; i < h1.Length; i++) {
			if (h1[i] == h2[i]) {
				continue;
			}

			switch (h1[i]) {
				case 'A':
					return 1;
				case 'K':
					if (h2[i] == 'A') {
						return -1;
					}
					return 1;
				case 'Q':
					if (h2[i] == 'A' || h2[i] == 'K') {
						return -1;
					}
					return 1;
				case 'J':
					if (h2[i] == 'A' || h2[i] == 'K' || h2[i] == 'Q') {
						return -1;
					}
					return 1;
				case 'T':
					if (h2[i] == 'A' || h2[i] == 'K' || h2[i] == 'Q' || h2[i] == 'J') {
						return -1;
					}
					return 1;
				default: // if h1 is a number
					if (h2[i] == 'A' || h2[i] == 'K' || h2[i] == 'Q' || h2[i] == 'J' || h2[i] == 'T') {
						return -1;
					}

					return Math.Max(h2[i] - '0', h1[i] - '0') == (h1[i] - '0') ? 1 : -1;

			}
		}

		throw new Exception("impossible case detected in sorting");
	}
}

