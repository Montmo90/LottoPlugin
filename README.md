# LottoPlugin
A Torch plugin for play Lotto in Space Engineers

## FILES
**Lotto/LottoConfig.cfg** - The config file *(all parameters can is change with a commands)*

**Lotto/LottoPlayersPlay.xml** - The list of players who have played the Lotto *(is reset for each new Lotto)*

**Lotto/LottoPlayersWin.xml** - The list of players win who have winning the Lotto *(is never reset)*

**Lotto/LottoTranslates.xml** - The translation file, you can edit it to change the text to display *(do not modify or delete "{0}" and other)*

## COMMANDS
### Lotto Help
```
!lotto help - Show all commands
!lotto info - Show information
!lotto play <number> - Play Lotto
!lotto recove - Allows you to recover your gain
```

### Settings:
```
!lotto config - Show configuration
!lotto open <bool> - Open or close the Lotto
!lotto number max <number> - Change the max number the player can play
```

### Ticket:
```
!lotto ticket prix <number> - Change the ticket price
!lotto ticket multiple <bool> - Players can play Lotto multiple times
```

### Gain:
```
!lotto gain <number> - Changes the winnings that are added to each Lotto whether it is ganged or lost
!lotto gain max <number> - Changes the maximum Lotto win
!lotto gain cumulate <bool> - Cumulate Lotto winnings as long as it is not won
!lotto gain add <number> - Adds an amount to the Lotto win
!lotto gain remove <number> - Remove an amount from the Lotto win
!lotto gain partage <bool> - Share the winnings among the winners or give the same winnings to each winner
```

### Draw:
```
!Lotto draw start - Perform a manual Lotto draw
!lotto draw auto <bool> - Activate or deactivate the automatic draft
!lotto draw days <b> <b> <b> <b> <b> <b> <b> - Change the automatic day draw (Sunday Monday Tuesday Wednesday Thursday Friday Saturday)
!lotto draw hour <HH:mm> - Set the Lotto draw time (ex: 06:00pm or 18:00)
!lotto save - Save all files
!lotto reload - Reload all files
```
