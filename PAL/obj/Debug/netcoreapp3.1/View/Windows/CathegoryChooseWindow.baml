   M S B A M L   `   `   `  ????=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PL.ViewModelPL.ViewModel  5      +    %PL.View.Windows.CathegoryChooseWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:PL.ViewModel     5        N? Title$  CathegoryChooseWindow??5	       ? 	Resources 5
         ZoomPercentageConverter??%   &	        	? 5   
   6"   5      .??5      ? .+?5   
   ? $??Stretch=?6   $??Stretch=?6+   ???	#FF00AEFF ? RowDefinitions 5      ?? 5      $??2* ?6    6.   ?? 5      $??5* ?6    6.   ?? 5      $??* ?6    6-    ? ColumnDefinitions 5      ?? 5      6%   .+?5      ?? -   5         ??Name$ ProductsListBox??5      $??1??5      $??0??6#   $??4??5      $??Stretch=?5      $
??Auto=?5       $ ?? IsSynchronizedWithCurrentItem$
 TrueY?5"      $
??1000??5#      $??Stretch=?5$      $??Stretch=?5%      ??5      ?? *
Categories+ ?? SelectedItem 5      ?? *SelectedCategory+??5&      ?? 5'       ?? 
TargetType" ??6    ?? Triggers 5(      P? 5)      	 P? Property	 ?@J?IsMouseOver
 P? Value$

 True??6=   . ?5*   "   ??  ?? Property ?@??
IsSelected ?? Value$
 True??6?   5+      5-      ??5/      ?? 50       ?? EndPoint$ 0.5,1&?6*    ?? 
StartPoint$ 0.5,0&?6;   .??51      ?  ? Color$ Black??6'    ? Offset$ 0Q?65   ? 52      $ White??6'   $ 1Q?65   ? 53      $ 	#FF00D1FF??6'   $ 0Q?69   ? 54      $ 	#FEFFFFFF??6'   $ 1Q?69   55      ??57      ?? 58      .R?5;      ?  ?Name$ 	wrapPanel??6$    ? Orientation$ 
Horizontal=?6w   ??67   ??  ?? Path$ ActualWidth? ?? ElementName$ ProductsListBox??5<      5=      ??5?      ?? 5@      .R?5A      ? $??80??6   $??Stretch=?6+   $??Stretch=?6I   $	??445??6e    5B      ?? 5C   "   .+?5E      ?? -   5        $??1??5E   )   $??Stretch=?69   .+?5F   "   ?? $??30(?6,    ?? TextAlignment$ Center=?6Y   ??6:   ?? *Category_Name+6Y   5G      5H      5I      5K      ?? 5M      $??0??6   $??0??6)   ???#00D1FF$??Stretch=?6K   .+?5N      ?? $??
ElectroNIX??6   $??Center=?6.   $??Center=?6K   $??72(?6f   $??	Motorwerk)?6t   ?? 5O       ?? Orientation$ 
Horizontal=?6   $??Center=?66   $??Stretch=?6S   5Q      5R      ?? 5T      $??0??6   $??2??6)   ???	#FF00AEFF$ 
Horizontal=?6M   $??Center=?6f   $??LeftToRight=?6?   $??Visible=?6?   $??Stretch=?6?   $??0,0,0,0q?6?   .+?5V      ?? -   5          ColorOverButtonChange#???  5V      $?? ??6I   $??30??6T   $??30??6`   ??5W      ?? 5X       ?? ImageSource$0 *Icons/ea0aee6ec78d9ec755e3102507320029.png??6%    j? Stretch$
 Fill=?6^    j? TileMode$
 None=?6m   5Z      ?? 5\      -   5        #???  5\      $?? ??6I   $??30??6T   $??30??6`    J? Opacity$	 0.9Q?6k   $|?False??6y   ??5]      ?? 5^      $) #Icons/free-icon-settings-126472.png??6%   $
 Fill=?6W   $
 None=?6f    ?? Opacity$ 1Q?6v   5`      ?? 5b      -   5        #???  5b      $?? ??6I   $??30??6T   $??30??6`   ??5c      ?? 5d      $ Icons/pngwing.com.png??6%   $
 Fill=?6I   $
 None=?6X   5f      ?? 5h      -   5        #???  5h      $?? ??6I   $??30??6T   $??30??6`   ??5i      ?? 5j      $) #Icons/free-icon-profile-1250689.png??6%   $
 Fill=?6W   $
 None=?6f   5l      5m      5n      5o      5p      